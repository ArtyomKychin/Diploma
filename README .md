
# Automated prestashop UI tests

This solution is a set of automatic Smoke tests executed in the space of an online women's clothing and accessories store http://prestashop.qatestlab.com


## Authors and Collaborators

- Autor [@ArtyomKychin](https://github.com/ArtyomKychin)
- Reviewer[@VladimirVolkov](https://github.com/VladimirVolkovD)


## Test Set

#### e2e Tests



| Parameter |  Description                |
| :-------- | :------------------------- |
| BasePathTest| Purchase of a single product through the transition to the product card|
| BasePathTestVsMoreProductsAndActivateQuickView|Purchase of several products through a pop-up product page with the input of data and the address of the buyer |

#### Other Tests


| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| AddressInputTest      | Positive | Checking the correct filling of the fields of the data entry form and the address of the buyer |
| AddressValidationTest     | Negative | Checking for incorrect filling in the fields of the data entry form and the address of the buyer |
| EmptyCartTest     | Negative |Checking the impossibility of continuing the purchase scenario without selecting a product|
| LoginStandartUser  | Positive |Authentication check using the correct data|
| LoginUncnownUser  | Negative |Authentication check using incorrect data|
| LogoutTest  | Positive |Checking out of account|
| ProductQuantityIconTest  | Positive |Сheck whether the quantity displayed on the cart icon matches the actual quantity of the selected items|
| AgreeTermsOfServiceTest  | Negative |Verification of the impossibility of executing the purchase scenario without confirming agreement with the terms of the provision of services|




## Used approaches to building a framework / tests

- Driver Factory
- Browser
- Page Object
- Wrappers
- Builder for model
- Chain of invocation
- Bogus



## Tech Stack

- Test framework:  - [NUnit](https://www.nuget.org/packages/NUnit)
- Logging: - [NLog](https://www.nuget.org/packages/NLog)
- Reporting - [Allure](https://www.nuget.org/packages/Allure.NUnit)
- Browser automation - [Selenium](https://www.nuget.org/packages/Selenium.WebDriver)
- Generator fake data - [Bogus](https://www.nuget.org/packages/Bogus)


## Installation

Register in [Prestashop](http://prestashop.qatestlab.com.ua/en/) using any random email and random password. Account verification is not required.

Clone repository Prestashop UI tests - [Diploma](https://github.com/ArtyomKychin/Diploma) repository.

Open solution in Visual studio (or other for C#).

Create solution build configurations Debug. 

Edit BrowserSetup.runsettings. Set your values.
Buid solution.

## Run Tests

For run test using .NET CLI, run the following command
```bash
   Dotnet test
```
## Generate Allure report
Firstly save a path where running tests data for a report saved.

 - Download and extract Allure.
 - Open folder with Allure bin, for example Х:\Allure\allure-x.xx.x\bin.
 - Run CMD in this folder.
 - Run command
 ```bash
   allure serve
```
- Allure report will be opened in your web browser.

    