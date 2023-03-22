# Boost for VGG Contrib

The `upstream` keeps a minified boost distribution with

- Complete boost headers
- Selected boost libs that VGG projects use, for space-saving purpose

The current boost sub-libs we are building

| Link Target: Static Lib | Notes                        |
| ----------------------- | ---------------------------- |
| `boost_thread`          |                              |
| `boost_atomic`          |                              |
| `boost_chrono`          |                              |
| `boost_container`       |                              |
| `boost_date_time`       |                              |
| `boost_exception`       |                              |
| `boost_locale`          |                              |
| `boost_context`         | Not available for EMSCRIPTEN |
| `boost_coroutine`       | Not available for EMSCRIPTEN |

If you want to add more libs, please copy files into `libs` directory from full boost distribution.

## Compiler support

As for the current boost version `1.80.0`, there is no official support for clang compiler of version > 15.

Because Emscripten uses clang 16 since [`3.1.18`](https://github.com/emscripten-core/emscripten/blob/main/ChangeLog.md#3118---08012022), you should use version `3.1.17` at most.
