using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;

// ReSharper disable InconsistentNaming
namespace Bookings.Specs.Specs
{
    public class AuthenticationService : IDisposable
    {
        public class Token
        {
            public string Username { get; private set; }
            public Guid SessionId { get; private set; }

            public Token(string username, Guid sessionId)
            {
                Username = username;
                SessionId = sessionId;
            }

            public bool IsValid {
                get { return SessionId != Guid.Empty; }
            }
        }

        public void Dispose()
        {

        }

        public Token Authenticate(string user, string password)
        {
            if (user == "user" && password == "password")
                return new Token("user",Guid.NewGuid());

            return new Token("anonymous",Guid.Empty);
        }
    }

    [Subject(typeof(AuthenticationService), "Authentication")]
    public class When_authenticating_a_user_with_valid_credentials
    {
        static AuthenticationService Service;
        static AuthenticationService.Token Token;
        
        Establish context = () =>
           Service = new AuthenticationService();

        Because of = () =>
           Token = Service.Authenticate("user", "password");

        It authentication_token_should_be_valid = () =>
            Token.IsValid.ShouldBeTrue();

        It authentication_toker_should_have_the_user_name_set = () =>
            Token.Username.ShouldBeLike("user");

        Cleanup after = () =>
           Service.Dispose();

    }
}
