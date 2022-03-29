/// <summary>
/// Summary description for EncryptDecrypt
/// </summary>
public class EncryptDecrypt
{
    public EncryptDecrypt()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    public static string Base64Decode(string base64EnCodeData)
    {
        var base64EncodeBytes = System.Convert.FromBase64String(base64EnCodeData);
        return System.Text.Encoding.UTF8.GetString(base64EncodeBytes);
    }
}