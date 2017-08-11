using System;
using System.Net;
using System.Net.Http;

namespace csharp_encode_decode_html
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "<html><head><meta http-equiv=\"Content - Type\" content=\"text / html; charset = us - ascii\"></head><body><table border=\"1\" cellpadding=\"0\" cellspacing=\"0\" width=\"100 % \"><tbody><tr><td><table align=\"center\" border=\"1\" cellpadding=\"0\" cellspacing=\"0\" width=\"1200\" style=\"border - collapse: collapse; \"><tbody><tr><td bgcolor=\"\" style=\"padding: 10px 10px 10px 10px; font - family: Calibri; font - size: 20px; \">Dear Customer,<br><br>Please note that the Expire Date or Balance Qty of the following items has exceeded the alert level.<br><br>Please check the details in ITS system, thank you!<br><br></td></tr><tr><td bgcolor=\"#FFECEC\" style=\"padding: 30px 30px 30px 30px;\"><table border=\"1\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"font-family: Calibri;\"><tbody><tr><td colspan=\"4\" style=\"text-align:center;\"><b>Balance Qty (First Level)</b></td></tr><tr><td><b>Category</b></td><td><b>Description</b></td><td><b>Alert Balance (1st)</b></td><td><b>Current Balance</b></td></tr><tr><td>Consumables </td><td>g5550 09339 </td><td>20 </td><td>13 </td></tr></tbody></table></td></tr><tr><td bgcolor=\"#FF5151\" style=\"padding: 30px 30px 30px 30px;\"><table border=\"1\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"font-family: Calibri;\"><tbody><tr><td colspan=\"4\" style=\"text-align:center;\"><b>Balance Qty (Second Level)</b></td></tr><tr><td><b>Category</b></td><td><b>Description</b></td><td><b>Alert Balance (2nd)</b></td><td><b>Current Balance</b></td></tr><tr><td>Consumables </td><td>5188 9026 </td><td>1 </td><td>1 </td></tr></tbody></table></td></tr><tr><td bgcolor=\"\" style=\"padding: 30px 30px 30px 30px;\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tbody><tr><td style=\"color: #000000; font-family: Arial, sans-serif; font-size: 14px;\" class=\"auto-style4\"><br><a href=\"#\" style=\"color: #ffffff;\"><font color=\"#000000\"></font></a>This is a system-generated email, please do not reply. Thanks</td><td></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></body></html>";
            string b = WebUtility.HtmlEncode(a);
            string c = WebUtility.HtmlDecode(b);
            Console.WriteLine("\nAfter HtmlEncode: " + b);
            Console.WriteLine("\nAfter HtmlDecode: " + c);

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62395/");
                    var response = client.PostAsJsonAsync("post", b).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Console.Write(response.Content.ReadAsStringAsync().Result);
                    }
                    else
                        Console.Write(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
