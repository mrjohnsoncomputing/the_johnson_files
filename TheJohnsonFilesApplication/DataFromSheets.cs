using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace TheJohnsonFilesApplication
{
    class DataFromSheets
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "TheJohnsonFiles";

        internal static string[] GetUser(string userID)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                //Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define request parameters.
            String spreadsheetId = "1b25bnYRkeOJppBuxKqqGq-w6Cm2FstxfOjM4axvvbXs";
            String range = "Participants!A2:G";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            if (values != null && values.Count > 0)
            { 
                foreach (var row in values)
                //for (int i = 0; i < values.Count; i++)
                {
                    if (row[0].ToString() == userID)
                    {
                        string[] studentdata = new string[row.Count];
                        for (int i = 0; i < row.Count; i++)
                        {
                            studentdata[i] = row[i].ToString();
                        }
                        return studentdata;
                    }
                    // Print columns A and E, which correspond to indices 0 and 4.
                    //Console.WriteLine("{0}, {1}", row[0], row[4]);
                }
            }
            else
            {
                Console.WriteLine("Error Connecting to Internet - The Johnson Files have failed.");
                
            }
            return new string[] { "-1" };
            //Console.Read();
        }
    }
}

