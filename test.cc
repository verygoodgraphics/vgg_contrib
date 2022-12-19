#include "MiniFB_cpp.h"
#include "nlohmann/json.hpp"
#include "picosha2.h"
#include "png.h"
#include "quickjs/quickjs.h"
#include "sdefl.h"
#include "sinfl.h"
#include "wasmtime.hh"
#include "webp/decode.h"
#include "webp/encode.h"
#include "zlib.h"
#include "zstd.h"

// this header should be put at the end due to missing dependent headers in GCC
#include "jpeglib.h"

int main() {

  wasmtime::Engine engine;

  return 0;
}
