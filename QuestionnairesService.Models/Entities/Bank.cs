namespace QuestionnairesService.Models.Entities
{
    public class Bank
    {
        public int Id { get; private set; }

        /// <summary>
        ///     Расчётный счёт.
        /// </summary>
        public string PaymentAccount { get; private set; } = null!;

        /// <summary>
        ///     БИК.
        /// </summary>
        public string BankCode { get; private set; } = null!;

        /// <summary>
        ///     Название филиала банка
        /// </summary>
        public string BranchOfficeName { get; private set; } = null!;

        /// <summary>
        ///     Корреспондентский счёт
        /// </summary>
        public string CorrespondentAccount { get; private set; } = null!;

        public Organization Organization { get; private set; } = null!;

        #region Constructors
        public Bank() { }

        public Bank(
            string bankCode,
            string branchOfficeName,
            string paymentAccount,
            string correspondentAccount,
            Organization limitedLiabilityCompany)
        {
            BankCode = bankCode;
            BranchOfficeName = branchOfficeName;
            PaymentAccount = paymentAccount;
            CorrespondentAccount = correspondentAccount;
            Organization = limitedLiabilityCompany;
        }
        #endregion
    }
}
