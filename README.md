# NUnit Test Harness

**2017-06-04**: This test harness was used to track a performance bug in NUnit. See https://github.com/nunit/nunit/issues/2217

**2017-06-08**: The bug has since been identified: https://github.com/nunit/nunit/issues/2217#issuecomment-307207993

**2017-06-08**: And resolved: https://github.com/nunit/nunit/pull/2233

The bug is present in NUnit versions v3.4.0 - v3.7.1 inclusive. NUnit 2.x is not affected.

~~Whilst the bug has been resolved the fix has not been published in a NUnit 3 release (yet).~~

To get nightly NUnit v3 build with the performance bug resolved you can use: https://www.myget.org/feed/nunit/package/nuget/NUnit/3.8.0-dev-04110

**2017-08-29**: v3.8 has been released https://github.com/nunit/nunit/releases/tag/3.8 which contains the performance bug fix.

#### What does AoC stand for?
AoC stands for [Advent of Code](https://adventofcode.com/).
