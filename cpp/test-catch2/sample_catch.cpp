#include <fstream>
#include <iostream>
#include <sstream>
#include <string>
#include <vector>
#include <filesystem>
#include "catch2/catch.hpp"
#include "RobotCleaner.h"
#include "OfficeCleaner01/Program.h"

using namespace std;

vector<pair<string, string>> stringProvider() {
    return {
            {"Input_empty.txt",        "=> Cleaned: 1"},
            {"Input_one.txt",          "=> Cleaned: 1"},
            {"Input_given_sample.txt", "=> Cleaned: 4"},
            {"Input_only_west.txt",    "=> Cleaned: 9"},
            {"Input_wiping.txt",       "=> Cleaned: 9"},
            {"Input_large.txt",        "=> Cleaned: 1047"}
    };
}

void DoRobotCleanerTest(string filename, const string &expected, function<void()> sut) {

    auto path = filesystem::path(__FILE__).parent_path();
    filename = path.string() + "/" + filename;
    auto originalCinBuf = cin.rdbuf();
    auto originalCoutBuf = cout.rdbuf();
    stringstream input, output;
    ifstream file(filename);
    cout << "Testing with " << filename << endl;
    REQUIRE(file.good());
    REQUIRE(file.is_open());

    cin.rdbuf(input.rdbuf());
    cout.rdbuf(output.rdbuf());

    input << file.rdbuf();
    sut();
    cout.flush();

    cin.rdbuf(originalCinBuf);
    cout.rdbuf(originalCoutBuf);

    string result = output.str();
    // Assuming the result format is the last line of output
    auto pos = result.rfind('\n', result.length() - 2);
    if (pos != string::npos) {
        result = result.substr(pos + 1);
    }
    // trim the result
    result.erase(result.find_last_not_of(" \n\r\t") + 1);
    REQUIRE(result == expected);
}

extern void OfficeCleaner9Main(); // Assuming this is declared elsewhere

TEST_CASE("OfficeCleaner9 Tests", "[OfficeCleaner9]") {
    for (auto &[filename, expected]: stringProvider()) {
        DoRobotCleanerTest(filename, expected, OfficeCleaner9Main);
    }
}

TEST_CASE("OfficeCleaner1 Tests", "[OfficeCleaner1]") {
    for (auto &[filename, expected]: stringProvider()) {
       DoRobotCleanerTest(filename, expected, OfficeCleaner01::OfficeCleaner1Main);
    }
}
