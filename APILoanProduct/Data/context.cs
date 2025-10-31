using APILoanProduct.Models;
using APILoanProduct.Models.BranchModule;
using APILoanProduct.Models.LoanApplications;
using APILoanProduct.Models.Roles;
using Microsoft.EntityFrameworkCore;

namespace APILoanProduct.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchLoanProduct> BranchLoanProducts { get; set; }
        public DbSet<LoanApplicantDetails> LoanApplicantDetails { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<LoanApplicationDocuments> LoanApplicationDocuments { get; set; }
        public DbSet<LoanApplicationReview> LoanApplicationReviews { get; set; }
        public DbSet<LoanDisbursement> LoanDisbursements { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<InterestRate> InterestRates { get; set; }
        public DbSet<LoanAmountDetails> LoanAmountDetails { get; set; }
        public DbSet<LoanDocuments> LoanDocuments { get; set; }
        public DbSet<LoanProduct> LoanProducts { get; set; }
        public DbSet<ProductAvailability> ProductAvailabilities { get; set; }
        public DbSet<RepaymentDetails> RepaymentDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Branch
            modelBuilder.Entity<Branch>()
                .HasKey(b => b.BranchId);

            modelBuilder.Entity<Branch>()
                .HasOne(b => b.BranchManager)
                .WithMany(u => u.ManagedBranches)
                .HasForeignKey(b => b.ManagerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // BranchLoanProduct
            modelBuilder.Entity<BranchLoanProduct>()
                .HasKey(blp => blp.BranchLoanProductId);

            modelBuilder.Entity<BranchLoanProduct>()
                .HasOne(blp => blp.Branch)
                .WithMany(b => b.BranchLoanProducts)
                .HasForeignKey(blp => blp.BranchId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BranchLoanProduct>()
                .HasOne(blp => blp.LoanProduct)
                .WithMany(lp => lp.BranchLoanProducts)
                .HasForeignKey(blp => blp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            //LoanProduct 
            modelBuilder.Entity<LoanProduct>()
                .HasKey(lp => lp.ProductId);

            modelBuilder.Entity<LoanProduct>()
                .HasOne(lp => lp.InterestRate)
                .WithOne(ir => ir.LoanProduct)
                .HasForeignKey<InterestRate>(ir => ir.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LoanProduct>()
                .HasOne(lp => lp.LoanAmountDetails)
                .WithOne(lad => lad.LoanProduct)
                .HasForeignKey<LoanAmountDetails>(lad => lad.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LoanProduct>()
                .HasOne(lp => lp.RepaymentDetails)
                .WithOne(rd => rd.LoanProduct)
                .HasForeignKey<RepaymentDetails>(rd => rd.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LoanProduct>()
                .HasOne(lp => lp.Documents)
                .WithOne(ld => ld.LoanProduct)
                .HasForeignKey<LoanDocuments>(ld => ld.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LoanProduct>()
                .HasOne(lp => lp.ProductAvailability)
                .WithOne(pa => pa.LoanProduct)
                .HasForeignKey<ProductAvailability>(pa => pa.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            //ProductAvailability
            modelBuilder.Entity<ProductAvailability>()
                .HasKey(pa => pa.AvailabilityId);

            modelBuilder.Entity<ProductAvailability>()
                .HasOne(pa => pa.Branch)
                .WithMany()
                .HasForeignKey(pa => pa.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            //InterestRate
            modelBuilder.Entity<InterestRate>()
                .HasKey(ir => ir.InterestId);

            //LoanAmountDetails 
            modelBuilder.Entity<LoanAmountDetails>()
                .HasKey(lad => lad.LoanAmountId);

            //LoanDocuments
            modelBuilder.Entity<LoanDocuments>()
                .HasKey(ld => ld.DocumentId);

            //RepaymentDetails
            modelBuilder.Entity<RepaymentDetails>()
                .HasKey(rd => rd.RepaymentId);

            // RoleMaster
            modelBuilder.Entity<RoleMaster>()
                .HasKey(r => r.RoleId);

            modelBuilder.Entity<RoleMaster>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            //UserMaster 
            modelBuilder.Entity<UserMaster>()
                .HasKey(u => u.UserId);

            //LoanApplication 
            modelBuilder.Entity<LoanApplication>()
                .HasKey(la => la.ApplicationId);

            modelBuilder.Entity<LoanApplication>()
                .HasOne(la => la.User)
                .WithMany()
                .HasForeignKey(la => la.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LoanApplication>()
                .HasOne(la => la.Branch)
                .WithMany(b => b.Loan_Application)
                .HasForeignKey(la => la.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            // LoanApplicantDetails
            modelBuilder.Entity<LoanApplicantDetails>()
                .HasKey(lad => lad.ApplicantDetailsId);

            modelBuilder.Entity<LoanApplicantDetails>()
                .HasOne(lad => lad.LoanApplication)
                .WithMany()
                .HasForeignKey(lad => lad.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            // LoanApplicationDocuments
            modelBuilder.Entity<LoanApplicationDocuments>()
                .HasKey(lad => lad.DocumentId);

            modelBuilder.Entity<LoanApplicationDocuments>()
                .HasOne(lad => lad.LoanApplication)
                .WithMany()
                .HasForeignKey(lad => lad.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            //LoanApplicationReview
            modelBuilder.Entity<LoanApplicationReview>()
                .HasKey(lar => lar.ReviewId);

            modelBuilder.Entity<LoanApplicationReview>()
                .HasOne(lar => lar.LoanApplication)
                .WithMany()
                .HasForeignKey(lar => lar.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LoanApplicationReview>()
                .HasOne(lar => lar.BranchManager)
                .WithMany()
                .HasForeignKey(lar => lar.ManagerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            //LoanDisbursement
            modelBuilder.Entity<LoanDisbursement>()
                .HasKey(ld => ld.DisbursementId);

            modelBuilder.Entity<LoanDisbursement>()
                .HasOne(ld => ld.LoanApplication)
                .WithMany()
                .HasForeignKey(ld => ld.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}