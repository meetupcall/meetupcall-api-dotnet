# meetupcall-api-dotnet
.NET Client for Meetupcall API.

A simple RestSharp based client library to access the Meetupcall API.

[Binaries available here.](MeetupcallApiClient.zip)

## Usage example
```csharp
using System;
using MeetupcallApiClient;

namespace meetupcalltest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Create a client and authenticate
			var client = new SignupClient("5d41de5a945e3bb36d93cbaf021ce1632f04cb84");

			// Create a new Signup
			var request = new SignupRequest {
				email = "john.smith+test@gmail.com",
				first_name = "John",
				last_name = "Smith",
				account_name = "Acme Corp",
				billing_street = "29 Acacia Road",
				billing_city = "London",
				billing_postal_code = "SW19 5AG",
				billing_country = "GB"
			};

			var new_signup = client.Create(request);

			// Other examples:

			// Get a collection of Signup(email,login_url) created with this api key
			var signups = client.Index();

			// Get a specific previously created Signup(email,login_url) created with this api key
			var signup = client.Get("john.smith+test@gmail.com");
		}
	}
}
```
