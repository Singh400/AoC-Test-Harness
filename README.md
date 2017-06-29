# AoC Test Suite

This test suite was used to track a performance bug in NUnit. See https://github.com/nunit/nunit/issues/2217

The bug has since been identified: https://github.com/nunit/nunit/issues/2217#issuecomment-307207993

And resolved: https://github.com/nunit/nunit/pull/2233

The bug is present in NUnit versions v3.4.0 onwards. NUnit 2.x is not affected.

Whilst the bug has been resolved the fix has not been published in a NUnit 3 release (yet). As it stands the versions (3.4.0 - 3.7.1 inclusive) available on Nuget
still have the performance bug.

To get a NUnit v3 with the performance bug resolve you can use: https://www.myget.org/feed/nunit/package/nuget/NUnit/3.8.0-dev-04110

#### What does AoC stand for?
AoC stands for [Advent of Code](https://adventofcode.com/).
