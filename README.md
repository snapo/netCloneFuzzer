# netCloneFuzzer
Website race-condition tester. With regular expressions on live HTTP/HTTPS events. This tool allows you to test any possible raceconditions with XML RPC interfaces / Databases / other backends...

# Sample
Use the url example.com, then use .net regular expressions to modify the header/body of the send message. Additionaly you can define how many times this request should be sent.
When a request is made, netCloneFuzzer holds it and prepare's all requests, as soon as all are prepared it releases them at once.

# Educational use only
This tool is only for educational purpose or to learn train working with fiddlercore and raceconditions.
You are not allowed to distribute it in any other way then this github repository.

# Used Package Versions
FiddlerCore.4.5.1.0

NUnit.2.6.4

