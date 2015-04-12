using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Deserializers;

namespace MeetupcallApiClient
{
	public class SignupUrl {
		public string Email { get; set; }
		public string LoginUrl { get; set; }
	}

	public class ApiStatus {
		public string code { get; set; }
		public string description { get; set; }
	}

	public class SignupsResponse {
		[DeserializeAs(Name = "status")]
		public ApiStatus status { get; set; }
		[DeserializeAs(Name = "data")]
		public List<SignupUrl> SignupUrls { get; set; }
	}

	public class SignupResponse {
		[DeserializeAs(Name = "status")]
		public ApiStatus status { get; set; }
		[DeserializeAs(Name = "data")]
		public SignupUrl SignupUrl { get; set; }
	}

	public struct SignupRequest {
		public string email { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string account_name { get; set; }
		public string billing_street { get; set; }
		public string billing_city { get; set; }
		public string billing_postal_code { get; set; }
		public string billing_country { get; set; }
		// Optional
		public string phone { get; set; }
		public string billing_state { get; set; }
		public string timezone { get; set; }
	}

	public class SignupClient
	{
		public string APIKey;
		public RestClient Client;

		public SignupClient(string APIKey)
		{
			this.APIKey = APIKey;
			Client = new RestClient("https://manage.meetupcall.com");
		}

		public SignupsResponse Index()
		{
			var request = new RestRequest("/api/v1/signups", Method.GET);
			request.AddHeader("x-api-key", APIKey);
			return Client.Execute<SignupsResponse>(request).Data;
		}

		public SignupResponse Get(string Email)
		{
			var request = new RestRequest("/api/v1/signups/{email}", Method.GET);
			request.AddUrlSegment("email", Email);
			request.AddHeader("x-api-key", APIKey);
			return Client.Execute<SignupResponse>(request).Data;
		}

		public SignupResponse Create(SignupRequest signupRequest)
		{
			var request = new RestRequest("/api/v1/signups", Method.POST);
			request.RequestFormat = DataFormat.Json;
			request.AddBody(signupRequest); 
			request.AddHeader("x-api-key", APIKey);
			return Client.Execute<SignupResponse>(request).Data;
		}
	}
}

