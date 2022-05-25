# Refund API project 

## Author Info

- LinkedIn - [William Peterson Kszan](https://www.linkedin.com/in/william-kszan-79b292105/)
- GitHub - [GitHub](https://github.com/Verthos)

### Table of Contents
- [Description](#description)
- [How To Use](#how-to-use)
- [License](#license)
- [Author Info](#author-info)

---

## Description

This is a project made in C# of an API to request, store and control refund requests.



#### Technologies

- C#
- .NET

[Back To The Top](#read-me-template)

## How To Use
The end-points are already working and require authentication to work.
I will complete this "How to use" section as soon as possible, showing what each user profile can and cannot do.

Feel free to make suggestions.

#### Installation
# To Run this application you will need to install SQL server, and .NET SDK, and make some small configurations.

# You will also need to configure into the project folder, the appsettings.json with some configurations. Here is what you need to input.
  "AllowedHosts": "*",
  "ConnectionStrings": {
      "DefaultConnection": "CONNECTION STRING TO YOUR DATABASE",
    "Production": "CONNECTION STRING TO YOUR DATABASE",
    "Development": "CONNECTION STRING TO YOUR DATABASE"
  },
  "Jwt": {
    "Key": "KEY TO GENERATE THE JWT TOKEN",
    "Issuer": "ISSUER URI IF YOU WANT (IN THIS VERSION (TEST ONLY) ITS DISABLE.",
    "Audience": "AUDIENCE URI IF YOU WANT (IN THIS VERSION (TEST ONLY) ITS DISABLE."
  }
  "EmailConfig": {
    "Host": "EMAIL HOST",
    "Username": "EMAIL LOGIN",
    "Password": "EMAIL PASSWORD"
  }

## License

MIT License

Copyright (c) [2022] [William Peterson Kszan]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

---
