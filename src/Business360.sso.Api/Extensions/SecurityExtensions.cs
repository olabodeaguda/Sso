using Business360.sso.Api.Utilities;
using IdentityServer4.Test;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business360.sso.Api.Extensions
{
    public static class SecurityExtensions
    {
        public static void SSoConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var builder = services.AddIdentityServer()
              .AddInMemoryIdentityResources(Config.Ids)
              .AddInMemoryApiResources(Config.Apis)
              .AddInMemoryClients(Config.Clients)
              .AddTestUsers(Users());

            builder.AddDeveloperSigningCredential();
            //services.AddIdentityServer(configuration)
            //    .AddSigningCredential(GetCertificate());

        }

        private static List<TestUser> Users()
        {
            return new List<TestUser>
            {
                new TestUser{ Username="naheem", Password="password", IsActive=true }
            };
        }

        private static X509Certificate2 GetCertificate()
        {
            string raw = @"MIIECTCCAvGgAwIBAgIUEnHtN3wHGSJ2oiwwJx0TFEYm1B8wDQYJKoZIhvcNAQEL
BQAwgZMxCzAJBgNVBAYTAk5HMRQwEgYDVQQIDAtCdXNpbmVzczM2MDEOMAwGA1UE
BwwFTGFnb3MxEzARBgNVBAoMCkVhc2V3YXJlTkcxCzAJBgNVBAsMAklUMRQwEgYD
VQQDDAtidXNpbmVzczM2MDEmMCQGCSqGSIb3DQEJARYXb2xhYm9kZTBhZ3VkYUBn
bWFpbC5jb20wHhcNMTkxMjA5MTM1MDE5WhcNMjAxMjA4MTM1MDE5WjCBkzELMAkG
A1UEBhMCTkcxFDASBgNVBAgMC0J1c2luZXNzMzYwMQ4wDAYDVQQHDAVMYWdvczET
MBEGA1UECgwKRWFzZXdhcmVORzELMAkGA1UECwwCSVQxFDASBgNVBAMMC2J1c2lu
ZXNzMzYwMSYwJAYJKoZIhvcNAQkBFhdvbGFib2RlMGFndWRhQGdtYWlsLmNvbTCC
ASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAMisVxf804VGEMK75z6+8Uzu
09CeMjj2huMOm6B6kQw7ePB8jRCOOl6NVfaPtSfc6nGMQId50guqBRakEILI4r+7
dasB9J9DuWh8RFBkEITtd2ncTWDSuG9/YmrJSd2+Ja/769WVhAHeG0IIWE8z5YGb
ZN1iJMsznnC3VrlFbANiFMjF7/zVaT06JV0BWtyyM+DYFT+PJ1usbw41uJl66G8I
Tq3V+ZyGD+aIiyN6fs3NftYwMZ8BlWhO5f2rx10jQcMsgE3RhNfXtbHjIdRZPTnO
1zrQF2jHKGxxELxHykoe9R9HRW70vigwhrEn4JtMxj/Cjp1dL6V5f5a9G1heyJ0C
AwEAAaNTMFEwHQYDVR0OBBYEFGRo4AOpsAFoFKfKDYhbOIgMsL4QMB8GA1UdIwQY
MBaAFGRo4AOpsAFoFKfKDYhbOIgMsL4QMA8GA1UdEwEB/wQFMAMBAf8wDQYJKoZI
hvcNAQELBQADggEBAJS5NteOhZPkSV8F9NtSUxp8hnkEiNqNt5Aq0SAqwIeG3OU4
C9WJxALRqsySM98Gi+rGHCsMu3Fc5NYupOkrUy/XsFxdUzwd6uOjQ7dEAidNsDm2
njF7F8+/sAaXzDtLWb3n5SFnLsBSaq9sDy6lBSJUoTdtxYE0pJY8NjZp2HIvOwUR
g1lvvjmSYhUKNxDJzW18azRK2JhGzHaoywWIJsQvEtV9T0MtdIWo8I4bXTr8s7FP
X0P5fLMd+hj//MU/eS9mTgU9BPgdow3CcrSCsHi6AlzBn03To3R69qphqZahJrOl
XGSgoeIETYiq3iBCuCh+d/PZMj1veqJ+guLRD/M=";


            byte[] byt = Encoding.UTF8.GetBytes(raw);
            return new X509Certificate2(byt, "@Olabode.123");
        }
    }
}
