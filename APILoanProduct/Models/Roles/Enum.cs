namespace APILoanProduct.Models.Roles
{

    public enum RoleTypes
    {
        Admin,
        Branch_Manager,
        User
    }
    public enum LoanProductCategory
    {
        PersonalLoan,
        BusinessLoan
    }
    public enum Interesttype
    {
        SimpleInterest,
        CompoundInterest
    }
    public enum LoanProductAvaliable 
    {
        Group,
        Client,
        Individual
    }
   public enum Employmentstatus
    {
        Student,
        Salaried,
        SelfEmployed,
        Freelancer,
    }
    public enum Loanapplicationstatus
    {
        Pending, 
        UnderReview,
        Approved,
        Rejected
    }
}
