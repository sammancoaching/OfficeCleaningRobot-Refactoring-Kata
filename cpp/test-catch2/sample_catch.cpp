#include "ApprovalTests.hpp"
#include "catch2/catch.hpp"


#include <iostream>
#include <fstream>
#include <string>

using namespace std;

TEST_CASE ("Sample") {
    SECTION("sample section") {
        REQUIRE(true == false);
    }
}

string DoRobotCleanerTest(const string &filename) {
    return "something";
}

TEST_CASE ("OfficeCleaner9") {
    std::streambuf *backupCin = cin.rdbuf();
    std::streambuf *backupCout = cout.rdbuf();

    auto expected_output = "hello world";

    SECTION("OfficeCleaner9") {

        auto actualOutput = DoRobotCleanerTest("Input_given_sample.txt");
        REQUIRE(actualOutput == expected_output);
    }


    cin.rdbuf(backupCin);
    cout.rdbuf(backupCout);
}


