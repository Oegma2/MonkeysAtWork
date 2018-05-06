# MonkeysAtWork
Load testing tool for servers, spawning millions of monkey's typing randomly to find that one right word, sentence or page

If you want to test this without compiling the code, you can download the files and go to the /build folder, containing compiled .exe file to run.

The MonkeysAtWork uses command line parameters - details below with an example

MonkeysAtWork [numoftimes] [method] "[message]"

   [numoftimes] - Provide a starting number between 0 and 32767 for how many times you want to run the test
   [method] - We provide two methods for running your load - CTest or STest
   [message] - This will be the message the monkey's need to try and type

Example of running your MonkeysAtWork for CTest method:
   MonkeysAtWork 100 CTest "Foxy"