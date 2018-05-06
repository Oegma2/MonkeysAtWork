![alt text](https://github.com/Oegma2/MonkeysAtWork/blob/master/maw.jpg)
# MonkeysAtWork
Load testing tool for servers, spawning millions of monkey's typing randomly to find that one right word, sentence or page

## Running .exe local
If you want to test this without compiling the code, you can download the files and go to the /build folder, containing compiled .exe file to run.

The MonkeysAtWork uses command line parameters - details below with an example

```
MonkeysAtWork [numoftimes] [method] "[message]"

   [numoftimes] - Provide a starting number between 0 and 32767 for how many times you want to run the test
   [method] - We provide two methods for running your load - CTest or STest
   [message] - This will be the message the monkey's need to try and type
```

```
Example of running your MonkeysAtWork for CTest method:
   MonkeysAtWork 100 CTest "Foxy"
```

## Future ideas
1. We planning on making MonkeysAtWork a container solution that can spawn easily on servers
2. Node based monkey's sending message for network traffic
3. Allow different code modules to be added, for hot swapping tests - idea is to see how your for-loop impact a certain server/container
4. Generate report after test-run
5. Send sms/email/notification once monkey's completed

## Status of the Project
This project is still under active development, so you might run into issues. 
If you do, please don't be shy about letting us know, or better yet, contribute a fix or feature.

## License
Apache License 2.0, see [LICENSE](https://github.com/Oegma2/MonkeysAtWork/blob/master/LICENSE).
