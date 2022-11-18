# VGG Contrib

This repo holds third-party libraries used in VGG projects.

Some rules for each library:

- Source-code only, no binaries, no submodules, no fetching scripts. Just code.
  - If the library is header-only, then a pre-built single-header file is prefered,
  - Otherwise the original library root is included.
- Dependencies of a library should be flattened out as other libraries in this repo
- The original code lies in `upstream` directory, while custom modifications lies in `patches` directory

## Library List

| Name                                            | License                                                      | Included Version                                             | Category    | Inclusion Type |
| ----------------------------------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ | ----------- | -------------- |
| [json](https://github.com/nlohmann/json)        | MIT                                                          | [3.11.2](https://github.com/nlohmann/json/releases/tag/v3.11.2) | json        | single header  |
| [picosha2](https://github.com/okdshin/PicoSHA2) | MIT                                                          | [7bfa26](https://github.com/okdshin/PicoSHA2/commit/7bfa26156981f7181f240906495a2c33c7fa48be) | hashing     | single header  |
| [sdefl/sinfl](https://github.com/vurtun/lib)    | MIT/Public Domain                                            | [71382a](https://github.com/vurtun/lib/commit/71382a1d14dad58219e7f6634d2381fa30dab175) | compression | single header  |
| [zlib](https://github.com/madler/zlib)          | [Custom](https://github.com/madler/zlib/blob/master/LICENSE) | [1.2.13](https://github.com/madler/zlib/releases/tag/v1.2.13) | compression | directory      |
| [zstd](https://github.com/facebook/zstd)        | BSD/GPLv2                                                    | [1.5.2](https://github.com/facebook/zstd/releases/tag/v1.5.2) | compression | directory      |
| [minifb](https://github.com/emoon/minifb)       | MIT                                                          | [5312cb](https://github.com/emoon/minifb/commit/5312cb7ca07115c918148131d296864b8d67e2d7) | window      | directory      |
|                                                 |                                                              |                                                              |             |                |

## How to use

Please first download this repo into your project, using whatever methods you like (for example, using `git submodule` or just a source code copy), and keep in your favorite place, for example, a folder in project root called `vgg_contrib`.

### Per-library usage

If you only need one specific library, for example, the `minifb` library, you could write in your `CMakeLists.txt`

```cmake
add_subdirectory(vgg_contrib/minifb)

target_include_directories(your_target PRIVATE ${VGG_CONTRIB_MINIFB_INCLUDE})
target_link_libraries(your_target minifb)
```

### All-Library usage

If you would like to use all the libraries, you can write in your `CMakeLists.txt`

```cmake
add_subdirectory(vgg_contrib)

target_include_directories(your_target PRIVATE ${VGG_CONTRIB_INCLUDE})
target_link_libraries(your_target minifb zlib libzstd_shared) # see summary below for full linkable targets
```

### Library usage summary

| Name        | Include Path                   | Link Target                                        |
| ----------- | ------------------------------ | -------------------------------------------------- |
| json        | `VGG_CONTRIB_JSON_INCLUDE`     | N/A                                                |
| picosha2    | `VGG_CONTRIB_PICOSHA2_INCLUDE` | N/A                                                |
| sdefl/sinfl | `VGG_CONTRIB_SDEFL_INCLUDE`    | N/A                                                |
| zlib        | `VGG_CONTRIB_ZLIB_INCLUDE`     | shared: `zlib`, static: `zlibstatic`               |
| zstd        | `VGG_CONTRIB_ZSTD_INCLUDE`     | shared: `libzstd_shared`, static: `libzstd_static` |
| minifb      | `VGG_CONTRIB_MINIFB_INCLUDE`   | static: `minifb`                                   |
|             |                                |                                                    |

For the specific header file usage, please refer to the `test.cc` for example.

## How to contribute

In order to add another library, please keep the following directory structure

```
vgg_contrib/
└── new_library/
    ├── CMakeLists.txt
    ├── patches/
    └── upstream/
```

where `upstream` is for original library root, and `pathces` is for custom modifications for upstream. A `CMakeLists.txt` sample is as follows

```
cmake_minimum_required(VERSION 3.7)

project(vgg_contrib_new_library)

add_subdirectory(upstream) # if this library has CMakeLists.txt in its root

set(VGG_CONTRIB_NEW_LIBRARY_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream/ CACHE PATH "" FORCE) # setup include path properly
mark_as_advanced(VGG_CONTRIB_NEW_LIBRARY_INCLUDE)
```

And don't forget to update `test.cc`, `CMakeLists.txt` and `README.md` in the root directory.
