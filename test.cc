#include "MiniFB_cpp.h"
#include "nlohmann/json-schema.hpp"
#include "nlohmann/json.hpp"
#include "picosha2.h"
#include "png.h"
#include "sdefl.h"
#include "sinfl.h"
#include "webp/decode.h"
#include "webp/encode.h"
#include "zlib.h"
#include "zstd.h"

// this header should be put at the end due to missing dependent headers in GCC
#include "jpeglib.h"

#include <iomanip>
#include <iostream>
using nlohmann::json;
using nlohmann::json_schema::json_validator;

void test_json_schema_validator() {
  json person_schema = R"({
    "$schema": "http://json-schema.org/draft-07/schema#",
    "title": "A person",
    "properties": {
        "name": {
            "description": "Name",
            "type": "string"
        },
        "age": {
            "description": "Age of the person",
            "type": "number",
            "minimum": 2,
            "maximum": 200
        }
    },
    "required": [
                 "name",
                 "age"
                 ],
    "type": "object"
  })"_json;
  json bad_person = {{"age", 42}};
  json good_person = {{"name", "Albert"}, {"age", 42}};

  json_validator validator; // create validator

  try {
    validator.set_root_schema(person_schema); // insert root-schema
  } catch (const std::exception &e) {
    std::cerr << "Validation of schema failed, here is why: " << e.what()
              << "\n";
    return;
  }

  for (auto &person : {bad_person, good_person}) {
    std::cout << "About to validate this person:\n"
              << std::setw(2) << person << std::endl;
    try {
      validator.validate(person); // validate the document - uses the default
                                  // throwing error-handler
      std::cout << "Validation succeeded\n";
    } catch (const std::exception &e) {
      std::cerr << "Validation failed, here is why: " << e.what() << "\n";
    }
  }
}

int main() {
  test_json_schema_validator();
  return 0;
}
