using System.Text.RegularExpressions;

string ipv4 = "192.168.1.1";
string ipv6 = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";
string neither = "123.256.-2.13";
Console.WriteLine("Ввод ipv4: " + ipv4);
Console.WriteLine(IpCheck(ipv4));
Console.WriteLine("Ввод ipv6: " + ipv6);
Console.WriteLine(IpCheck(ipv6));
Console.WriteLine("Ввод неподходящей строки: " + neither);
Console.WriteLine(IpCheck(neither));


string IpCheck(string ip)
{
    if (ip.Contains('.') && IpV4check(ip))
        return "IPv4";

    if (ip.Contains(':') && Regex.Matches(ip, ":").Count == 7 && IpV6check(ip))
        return "IPv6";

    return "Neither";
}


bool IpV4check(string ip)
{
    string[] ipmass = ip.Split('.');
    if (ipmass.Length != 4) return false;

    for (int index = 0; index < ipmass.Length; index++)
    {
        try
        {
            if (Convert.ToInt32(ipmass[index]) >= 0 && Convert.ToInt32(ipmass[index]) <= 255) { }
            else return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    return true;
}

bool IpV6check(string ip)
{
    string[] ipmass = ip.Split(':');
    for (int index = 0; index < ipmass.Length; index++)
    {
        if (ipmass[index].Length >= 1 && ipmass[index].Length <= 4) 
        {
            try
            {
                int ippartin16x = Convert.ToInt32(ipmass[index], 16);
            }
            catch (Exception)
            {
                return false;
            }
        }
        else return false;
    }
    return true;
}