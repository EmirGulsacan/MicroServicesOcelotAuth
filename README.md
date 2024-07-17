# MicroServicesOcelotAuth

This project is a Proof of Concept (PoC) for implementing a microservices architecture using Ocelot as the API Gateway.
It consists of three web APIs: AuthAPI, CustomerAPI, and ProductAPI. The users will send requests to the APIs through the APIGateway.
The AuthAPI is used to obtain a token, which is then used to access the CustomerAPI and ProductAPI.

## Project Structure

- **AuthAPI**: Handles authentication and token generation.
- **CustomerAPI**: Manages customer-related operations.
- **ProductAPI**: Manages product-related operations.
- **APIGateway**: Routes requests to the appropriate downstream services.

## Prerequisites
.NET 5.0 or later
Docker (optional for containerized deployment)

## Configuration
Ocelot Configuration
The routing and authentication configuration for Ocelot is defined in ocelot.json:
```ocelot.json
   "Routes": [
      {
         "DownstreamPathTemplate": "/api/products",
         "DownstreamScheme": "https",
         "DownstreamHostAndPorts": [
             {
                 "Host": "localhost",
                 "Port": 1000
             }
         ],
         "UpstreamPathTemplate": "/api/products",
         "UpstreamHttpMethod": [ "Get" ],
         "AuthenticationOptions": {
            "AuthenticationProviderKey": "TestKey",
            "AllowedScopes": []
          }
      },
      {
         "DownstreamPathTemplate": "/api/customers",
         "DownstreamScheme": "https",
         "DownstreamHostAndPorts": [
             {
                 "Host": "localhost",
                 "Port": 2000
             }
         ],
         "UpstreamPathTemplate": "/api/customers",
         "UpstreamHttpMethod": [ "Get" ]
      },
      {
         "DownstreamPathTemplate": "/api/auths",
         "DownstreamScheme": "https",
         "DownstreamHostAndPorts": [
             {
                 "Host": "localhost",
                 "Port": 3000
             }
         ],
         "UpstreamPathTemplate": "/api/auths",
         "UpstreamHttpMethod": [ "Get" ]
      }
   ],
   "GlobalConfiguration": {
       "BaseUrl": "https://localhost:4000"
   }

```
## Authentication Setup
1.Clone the repository:
```bash
git clone https://github.com/EmirGulsacan/MicroServicesOcelotAuth.git
cd MicroServicesOcelotAuth
```
2.Start the services:
```bash
Navigate to each API project directory (AuthAPI, CustomerAPI, ProductAPI, APIGateway) and run the following command:
dotnet run
```
3.Accessing the APIs:
```bash
Obtain a token from AuthAPI via the API Gateway:

GET https://localhost:4000/api/auths

Use the obtained token to access CustomerAPI and ProductAPI:

GET https://localhost:4000/api/customers
GET https://localhost:4000/api/products
```
## Notes
Ensure that each API is configured to run on the specified ports (1000, 2000, 3000) in the Ocelot configuration.
Use HTTPS to ensure secure communication between the services and the API Gateway.
Customize the ocelot.json configuration as needed for your specific use case.

## Troubleshooting
Verify that each API is running and accessible on the specified ports.
Check the API Gateway logs for any routing or authentication errors.
Ensure that the authentication middleware is correctly configured in the API Gateway project.

## References
- **Ocelot Documentation** : https://ocelot.readthedocs.io/en/latest/
- **.NET Documentation** : https://docs.microsoft.com/en-us/dotnet/

## License
This project is licensed under the MIT License. See the LICENSE file for more details.


