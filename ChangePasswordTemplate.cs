namespace PracticeMVC_DB_Identitty.Helper
{
    public class ChangePasswordTemplate
    {
        public static string PasswordChangedTemplate(string username)
        {
            return $@"
<div style='max-width:600px;margin:auto;font-family:Segoe UI,Arial,sans-serif;background:#f4f6f9;padding:20px;'>

    <div style='background:#ffffff;border-radius:12px;overflow:hidden;box-shadow:0 6px 15px rgba(0,0,0,0.1);'>
        
        <div style='background:linear-gradient(135deg,#667eea,#764ba2);padding:25px;text-align:center;color:white;'>
            <h2>🔐 Password Changed</h2>
            <p>Security Notification</p>
        </div>

        <div style='padding:25px;color:#2d3436;'>

            <p>Hello <b>{username}</b>,</p>

            <p>Your password was changed on <b>{DateTime.Now:f}</b>.</p>

            <div style='background:#ffeaea;padding:15px;border-left:5px solid red;'>
                <b>If this was not you, reset your password immediately.</b>
            </div>

            <p style='margin-top:20px;'>Regards,<br><b>Support Team</b></p>
        </div>

        <div style='background:#f8f9fa;padding:10px;text-align:center;font-size:12px;color:#999;'>
            © {DateTime.Now.Year} Rushikesh Shejul
        </div>
    </div>
</div>";
        }
    }
}

