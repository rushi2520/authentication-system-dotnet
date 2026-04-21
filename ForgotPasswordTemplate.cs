using Azure.Core;
using System.Drawing;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;
using static System.Net.Mime.MediaTypeNames;

namespace PracticeMVC_DB_Identitty.Helper
{
    public class ForgotPasswordTemplate
    {
        public static string PasswordChangedTemplate(string username,string secureLink)
        {
            return $@"
<div style=""max-width: 600px; margin: 20px auto; font-family: 'Segoe UI', Helvetica, Arial, sans-serif; background-color: #f9f9f9; padding: 20px; border-radius: 15px;"">
    <div style=""background-color: #ffffff; border-radius: 12px; overflow: hidden; box-shadow: 0 10px 25px rgba(0,0,0,0.06); border: 1px solid #e1e1e1;"">
        
        <div style=""background: linear-gradient(135deg, #0d6efd, #0046af); padding: 30px; text-align: center;"">
            <h1 style=""color: #ffffff; margin: 0; font-size: 24px; letter-spacing: 1px;"">Password Reset</h1>
        </div>

        <div style=""padding: 40px; color: #444; line-height: 1.8;"">
            <p style=""font-size: 18px; margin-top: 0;"">Hello <strong>{username}</strong>,</p>
            
            <p>We received a request to reset the password for your account. No worries, it happens to the best of us! Click the secure button below to choose a new one:</p>
            
            <div style=""text-align: center; margin: 40px 0;"">
                <a href=""{secureLink}"" style=""background-color: #0d6efd; color: #ffffff; padding: 16px 35px; text-decoration: none; font-weight: bold; border-radius: 50px; display: inline-block; font-size: 16px; box-shadow: 0 4px 12px rgba(13, 110, 253, 0.3);"">
                    Reset My Password
                </a>
            </div>
            
            <div style=""background-color: #fff8e1; border-left: 4px solid #ffc107; padding: 15px; margin-bottom: 25px; border-radius: 4px;"">
                <p style=""font-size: 13px; color: #856404; margin: 0;"">
                    <strong>Security Note:</strong> This link is valid for a limited time. If you didn't request this change, please ignore this email or contact support.
                </p>
            </div>
            
            <hr style=""border: 0; border-top: 1px solid #eee; margin: 30px 0;"" />
            
            <p style=""font-size: 12px; color: #999; line-height: 1.5; word-break: break-all;"">
                <strong>Button not working?</strong> Copy and paste this URL into your browser:<br />
                <a href=""{secureLink}"" style=""color: #0d6efd; text-decoration: none;"">{secureLink}</a>
            </p>
            
            <p style=""margin-top: 30px; margin-bottom: 0;"">
                Best regards,<br />
                <span style=""font-size: 18px; font-weight: bold; color: #0d6efd;"">Rushikesh Shejul</span><br />
                <span style=""color: #888; font-size: 13px;""></span>
            </p>
        </div>
        
        <div style=""background-color: #f1f1f1; padding: 20px; text-align: center; font-size: 11px; color: #aaa;"">
            © {DateTime.Now.Year} Indian School of Coding. All rights reserved.<br />
            You are receiving this because a password reset was requested for your account.
        </div>
    </div>
</div>";
        }
        }
}
