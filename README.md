[![npm package](https://img.shields.io/npm/v/com.rmc.rmc-readme)](https://www.npmjs.com/package/com.rmc.rmc-readme)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)

# RMC ReadMe

The readme library for Unity for RUNTIME usage. The end-user only needs this package.

If you also want to AUTHOR the experience, see https://github.com/SamuelAsherRivello/rmc-readme-authoring.


# Table Of Contents

- [Install](#install)
  - [via Git URL](#via-git-url)
  - [Tests](#tests)

<!-- toc -->

## Install

### via Git URL

Open `Packages/manifest.json` with your favorite text editor. Add following line to the dependencies block:
```json
{
  "dependencies": {
    "com.rmc.rmc-readme": "https://github.com/SamuelAsherRivello/rmc-readme.git"
  }
}
```

### Tests

The package can optionally be set as *testable*.
In practice this means that tests in the package will be visible in the [Unity Test Runner](https://docs.unity3d.com/2017.4/Documentation/Manual/testing-editortestsrunner.html).

Open `Packages/manifest.json` with your favorite text editor. Add following line **after** the dependencies block:
```json
{
  "dependencies": {
  },
  "testables": [ "com.rmc.rmc-readme" ]
}
```

### Import Samples
To see clear use cases, import and run the samples:

1. Open Unity and then open `Window > Package Manager`
1. Select `RMC ReadMe` 
1. Select Samples and import

Created By
=============

- Samuel Asher Rivello 
- Over 23 years XP with game development (2023)
- Over 10 years XP with Unity (2023)

Contact
=============

- Twitter - <a href="https://twitter.com/srivello/">@srivello</a>
- Resume & Portfolio - <a href="http://www.SamuelAsherRivello.com">SamuelAsherRivello.com</a>
- Git - <a href="https://github.com/SamuelAsherRivello/">Github.com/SamuelAsherRivello</a>
- LinkedIn - <a href="https://Linkedin.com/in/SamuelAsherRivello">Linkedin.com/in/SamuelAsherRivello</a> <--- Say Hello! :)




