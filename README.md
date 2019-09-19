#### Test Objectives

This is your assignment, as we spoke in the call this is the last part of the interview.

Please send your results in no more than 24 hours (I’m ok if you send it until 12am of the next day but not more than that), send it via git repository or google drive link.

Images, PDF’s or txt files are not allowed.

 

    Go to Amazon.com
    Search for Samsung Galaxy S9 - store the price
    Click on the First Result
    Once in the details page compare this price vs the above one
    Click on Add to Cart.
    Go to Amazon main page
    Click on "Your Amazon.com" button
    Click on "Create Your Amazon Account"
    Fill all the fields and do not click on Create your Amazon account button
    Validate that the text is preset: "Create account"

 

Acceptance Criteria

    Use POM and Page Factory
    Use TestNG or Cucumber
    Use a configuration file could be Json or XML
    Use Assertions
    At least have an interface or abstract class

 

Thank you! 


#### Running Tests
You can run them in the Unit Test explorer of your chosen IDE or via command line

Build
```
$ msbuild
```

Run tests
```
$ mono "packages/xunit.runner.console.2.4.1/tools/net452/xunit.console.exe" SpecFlow.Selenium/bin/Debug/SpecFlow.Selenium.dll -xml ./TestResults/xunit.xml
```

Selection of browser is through an environment variable. Defaults to Chrome if unprovided.
```
$ BROWSER=firefox mono "packages/xunit.runner.console.2.4.1/tools/net452/xunit.console.exe" SpecFlow.Selenium/bin/Debug/SpecFlow.Selenium.dll -xml ./TestResults/xunit.xml
```

Then you can generate a nice html report via Pickles
```
$ mono "packages/Pickles.CommandLine.2.20.1/tools/pickles.exe" --feature-directory=SpecFlow.Selenium/Features/ --output-directory=./TestResults/pickles --link-results-file=./TestResults/xunit.xml --documentation-format=dhtml --test-results-format=xunit2
```
