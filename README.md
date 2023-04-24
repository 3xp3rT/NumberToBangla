# .Net package to get English number to (Bangla digits or Bangla word), Bangla month name ,Bangla dayname, Bangla money in (word or digits or comma-separate) for .Net Core. 
# Maximum possible number to covert in Bangla word is 999999999999999

## Example,
| Function |  Input |  Output |
| --- | --- | --- |
| GetBanglaWord | 100099645 |দশ কোটি নিরানব্বই হাজার ছয় শত পঁয়তাল্লিশ|
| GetBanglaDigits | 1234567.84 |১২৩৪৫৬৭.৮৪|
| GetCommaSeparateBanglaDigit | 1000000 |১০,০০,০০০|
| GetTakaInWord | 10.89 |দশ টাকা ঊননব্বই পয়সা|
| GetBanglaMonthName | 12 |ডিসেম্বর|
| GetBanglaDayName | 7 |বৃহস্পতিবার|


## Installation

Install the package with Nuget Package Manager.
Search on Tools-> Nuget Package Manager-> Manage Nuget Package Manager for Solution-> Browse "NumberToBangla" -> NumberToBangla by Md Nakibul Islam Shaki
On the command line:
```
dotnet add package NumberToBangla --version 1.0.4
```

## How to use it?
First add the package 
then write  NumberToBanglaGenerator 
then add reference 
you get suggetion (GetBanglaWord, GetBanglaDigits, GetCommaSeparateBanglaDigit, GetTakaInWord, GetBanglaMonthName,GetBanglaDayName) functions.

    <p>@NumberToBanglaGenerator.GetCommaSeparateBanglaDigit(1000000)</p>
    <p>@NumberToBanglaGenerator.GetBanglaDigits(1234567.84)</p>
    <p>@NumberToBanglaGenerator.GetBanglaWord(100099645)</p>
    <p>@NumberToBanglaGenerator.GetTakaInWord(10.89)</p>
    <p>@NumberToBanglaGenerator.GetBanglaMonthName(4)</p>
    <p>@NumberToBanglaGenerator.GetBanglaDayName(1)</p>
