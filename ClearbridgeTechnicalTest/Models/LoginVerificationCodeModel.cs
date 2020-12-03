using ClearbridgeTechnicalTest.Models;

namespace ClearbridgeTechnicalTest.Controllers
{
    public class LoginVerificationCodeModel : LoginModel
    {
        public string VerificationCode { get; set; }

        public LoginVerificationCodeModel() : base()
        {

        }

        public override bool Validate()
        {
            LoginLogRepository loginLogRepository = new LoginLogRepository();
            LoginLog loginLog = loginLogRepository.GetLastestLoginLog(base.Email);

            return loginLog.LoginVerificationCode.Code == this.VerificationCode;
        }
    }
}