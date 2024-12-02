# SimpleExchangeAPI

SimpleExchangeAPI Readme

1. How to open it
Use Visual Studio 2022 (Preferrably the latest stable version - 17.12.2) to open the "SimpleExchangeAPI.sln" file. 
Then wait until the projects are fully loaded.


2. How to run it
In Visual Studio 2022, right click on the SimpleExchangeAPI project, select "Set as Startup Project" on context menu.
Then press Ctrl + F5 to run the SimpleExchangeAPI project without debugging, it should show Swagger Index Page in your linked browser.
Note: In rare case, if it doesn't work do a Clean + Build on solution (clean it first, then build it but not rebuild) then press Ctrl + F5 to try again. If still doesn't work call me on 0404393072 for help/assistance


3. How to test it
Keep the SimpleExchangeAPI project running, as done in step 2.

a) On above Swagger index page, you can test the locally deployed endpoint freely, any exception thrown from any thread (if Compute-bound) or any non-thread based tasks (if IO-bound) should be caught and handled, and has the logic to return a proper very detailed message back to client. (If you don't want to expose the stack trace to external clients, then can change code to not show it)
As it's 1~2 hour coding test, logging is yet to be implemented, as commented in code it can use Microsoft.Extensions.Logging's logger or log4net, nLog, etc., etc. Choose one most suitable for it.

b) You can also use some simple and popular API platforms e.g. Postman to test API by sending curl requests to endpoint.
As mentioned in the coding requirement, curl request would be (also in ..\_Requirements\curl_request.txt):

curl -X 'POST' \
 'http://localhost:5288/ExchangeService' \
 -H 'accept: text/plain' \
 -H 'Content-Type: application/json' \
 -d '{
 "amount": 5,
 "inputCurrency": "AUD",
 "outputCurrency": "USD"
}'

Open Postman, import the above curl request, then test it by clicking "Send" button to send the HttpPost request.
Note: In rare case, if there is a conflict in port, change the port of url to the correct value in the curl request before importing it

c) You can also use the SimpleExchangeAPI.Tests NUnit project for unit testing.
   As it's 1~2 hour coding test, such unit test is only briefly implemented which you can run from within VS (Test -> Run or debug tests). More importantly I can also add code for integration testing by testing the actual endpoint in code if you need or use some integration testing and/or system testing tools to help you do that in Development and Staging Environments.
   If you have QA, then can work with QA on UAT (user acceptance testing) in Staging envi6ronment before deploying to Production environment; If not can test by senior developers ourselves in Staging.


4. How to deploy/release it (Development, Staging and Production environments - or any one(s) of these)
It depends on your existing IT infrastructure, e.g. whether your team uses DevOps and CI/CD pipelines for automated workflows, whether to deploy to cloud (AWS, Azure, etc.) purely or you also use on-site dedicated servers for deployment, etc.
I am very confident in solving all of any technical issues.


Last but not least, the naming convention and/or conding styles can be changed of course to suit your teams needs for coding convention, e.g. class members such as fields, properties, methods as well as non-class member such as local variable naming convention, and use of OOD/OOP, SOLID and suitable Creational/Structural/Behavioral design patterns on higher level in application architecture and more granular levels in smaller sections of code, etc. I have a lot of experience on full-stack .NET project development in complete SDLC and can give you excellent results very quickly. My phone number is 0404393072, call me if you need. I can work on-site, hybrid, or remotely. Thank you for your time!


Sincerely,
James
