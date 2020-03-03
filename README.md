# Refrigerator

## Foreword

I created this simple project for my personal assessment. The idea is from the website. This project is all about managing (creating, reading, deleting, updating) foods (edibles, drinks, etc.) in refrigerators. The structure of the application is the following:

1. API - that contains the logic
    * Consumable class
        * Edible class
        * Drinkable class
    * Fridge class
    * IStorable interface
    * Exception classes
2. Program - the main
    * UI class - responsible for printing
    * Menu class - responsible for handling user inputs and using UI
    * DataManager class - XML import/export handling

___

## How it works

In order to start this fantastic application you have to type in the following:

```
dotnet run [filename.xml]
```

Without giving the file path argument it won't start.

After that you will see the *main menu* where you can add fridges if you want. After successfully getting over it follow the **instructions**.

Bear in mind that **not all exceptions** are handled, therefore it may be **buggy**.
