# VGG Contrib

This repo holds third-party libraries used in VGG projects.

Some rules for each library:

- Source-code only, no binaries, no submodules, no fetching scripts. Just code.
  - If the library is header-only, then a pre-built single-header file is prefered,
  - Otherwise the library directory is included.
- Dependencies of a library should be flattened out as other libraries in this repo
- The original code lies in `upstream` directory, with modifications if neccessary
- The modifications to the original code lie in `patches` directory

## Library List

| Name                                            | License                                                      | Included Version                                             | Category    | Inclusion Type |
| ----------------------------------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ | ----------- | -------------- |
| [json](https://github.com/nlohmann/json)        | MIT                                                          | [3.11.2](https://github.com/nlohmann/json/releases/tag/v3.11.2) | json        | single header  |
| [picosha2](https://github.com/okdshin/PicoSHA2) | MIT                                                          | [7bfa26](https://github.com/okdshin/PicoSHA2/tree/7bfa26156981f7181f240906495a2c33c7fa48be) | hashing     | single header  |
| [sdefl/sinfl](https://github.com/vurtun/lib)    | MIT/Public Domain                                            | [71382a](https://github.com/vurtun/lib/tree/71382a1d14dad58219e7f6634d2381fa30dab175) | compression | single header  |
| [zlib](https://github.com/madler/zlib)          | [Custom](https://github.com/madler/zlib/blob/master/LICENSE) | [1.2.13](https://github.com/madler/zlib/releases/tag/v1.2.13) | compression | directory      |
| [zstd](https://github.com/facebook/zstd)        | BSD/GPLv2                                                    | [1.5.2](https://github.com/facebook/zstd/releases/tag/v1.5.2) | compression | directory      |
| [minifb](https://github.com/emoon/minifb)       | MIT                                                          | [feature-vgg](https://github.com/verygoodgraphics/minifb/tree/feature-vgg) | window      | directory      |
| [libpng](https://sourceforge.net/projects/libpng/) | [Custom](http://www.libpng.org/pub/png/src/libpng-LICENSE.txt) | [1.6.38](https://sourceforge.net/projects/libpng/files/libpng16/1.6.38/) | image       | directory      |
| [libjpeg-turbo](https://github.com/libjpeg-turbo/libjpeg-turbo) | [Custom](https://github.com/libjpeg-turbo/libjpeg-turbo/blob/main/LICENSE.md) | [2.1.4](https://github.com/libjpeg-turbo/libjpeg-turbo/releases/tag/2.1.4) | image | directory |
| [libwebp](https://github.com/webmproject/libwebp) | BSD | [1.2.4](https://github.com/webmproject/libwebp/releases/tag/v1.2.4) | image | directory |
| [boost](https://www.boost.org/) | [Boost](https://www.boost.org/users/license.html) | [1.80.0](https://www.boost.org/users/history/version_1_80_0.html) | common | directory |
| [valijson](https://github.com/tristanpenman/valijson) | BSD | [feature-vgg](https://github.com/verygoodgraphics/valijson/tree/feature-vgg) | json schema | single header |
| [zip](https://github.com/kuba--/zip) | [UNLICENSE](https://github.com/kuba--/zip/blob/master/UNLICENSE) | [0.2.6](https://github.com/kuba--/zip/releases/tag/v0.2.6) | zip | directory |
| [nanobind](https://github.com/wjakob/nanobind) | BSD-3-Clause | [1.1.1](https://github.com/wjakob/nanobind/releases/tag/v1.1.1) | binding | directory |
| [glm](https://github.com/g-truc/glm) | [The Happy Bunny License or MIT](https://github.com/g-truc/glm/blob/master/manual.md#section0) | [0.9.9.8](https://github.com/g-truc/glm/releases/tag/0.9.9.8) | math | directory |

If you encounter compiling issues for boost, please refer to boost's [README](./boost/README.md).

## How to use

Please first download this repo into your project, using whatever methods you like (for example, using recommended `git submodule` or just a source code copy), and keep it in your favorite place, for example, a folder in project root called `vgg_contrib`.

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

| Name          | Include Path                                                 | Link Target                                                  |
| ------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| json          | `VGG_CONTRIB_JSON_INCLUDE`                                   | N/A                                                          |
| picosha2      | `VGG_CONTRIB_PICOSHA2_INCLUDE`                               | N/A                                                          |
| sdefl/sinfl   | `VGG_CONTRIB_SDEFL_INCLUDE`                                  | N/A                                                          |
| zlib          | `VGG_CONTRIB_ZLIB_INCLUDE`<br />`VGG_CONTRIB_ZLIB_CONF_INCLUDE` | shared: `zlib`, static: `zlibstatic`                         |
| zstd          | `VGG_CONTRIB_ZSTD_INCLUDE`                                   | shared: `libzstd_shared`, static: `libzstd_static`           |
| minifb        | `VGG_CONTRIB_MINIFB_INCLUDE`                                 | static: `minifb`                                             |
| libpng        | `VGG_CONTRIB_LIBPNG_INCLUDE`<br />`VGG_CONTRIB_LIBPNG_CONF_INCLUDE` | shared: `png`, static: `png_static`                          |
| libjpeg-turbo | `VGG_CONTRIB_LIBJPG_INCLUDE`<br />`VGG_CONTRIB_LIBJPG_CONF_INCLUDE` | shared: `jpeg`, static: `jpeg-static`                        |
| libwebp       | `VGG_CONTRIB_LIBWEBP_INCLUDE`<br />`VGG_CONTRIB_LIBWEBP_CONF_INCLUDE` | static: `webp`                                               |
| boost         | `VGG_CONTRIB_BOOST_INCLUDE`                                  | static libs, see boost's [README](./boost/README.md)         |
| valijson      | `VGG_CONTRIB_VALIJSON_INCLUDE`                               | N/A                                                          |
| zip           | `VGG_CONTRIB_ZIP_INCLUDE`                                    | static:`zip`                                                 |
| nanobind      | [N/A (implicitly added by `nanobind_add_module`)](https://nanobind.readthedocs.io/en/latest/building.html#building-an-extension) | [N/A (implicitly added by `nanobind_add_module`)](https://nanobind.readthedocs.io/en/latest/building.html#building-an-extension) |
| glm           | `VGG_CONTRIB_GLM_INCLUDE`                                    | N/A                                                          |

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

```cmake
cmake_minimum_required(VERSION 3.7)

project(vgg_contrib_new_library)

add_subdirectory(upstream) # only if this library has CMakeLists.txt, otherwise you have to write your own

set(VGG_CONTRIB_NEW_LIBRARY_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream/ CACHE PATH "" FORCE) # setup include path properly
mark_as_advanced(VGG_CONTRIB_NEW_LIBRARY_INCLUDE)
```

And don't forget to update `test.cc`, `CMakeLists.txt` and `README.md` in the root directory.

### Tips

When adding third-party source code in upstream folder, it is highly possible that some files are not added to the git version control because of rules in `.gitignore` in its directories. To list all files that is not added, use the command to find out

```bash
git clean -fdnx
```

and decide whether or not to forcibly add those missing files using `git add -f`. Look out!

## About patching

Sometimes it is neccessary to patch the library source code to meet our needs, and it is a good practice to keep track of the changes in patch files. For example, if the upstream got updated, we could just re-patch the code effortlessly.

In this project, we assume all the code in `upstream` directory is already patched so that we could use it at ease.

### How to make a patch

Take the `sdefl` library for example. Say we have made changes to `upstream/sinfl.h` **in place**, and the original code have been copied as the `original` folder. We could use the following command to make a new patch

```bash
diff -ru original/ upstream/ > patches/00-patch.applied
```

### How to apply a patch

If we update the `sinfl.h` to the latest upstream version, un-patched, we could use the following command to re-patch this file

```bash
cd upstream/
patch -p1 < ../patches/00-patch.applied
```

### How to revert a patch

If we need to use the original `sinfl.h`, we use the following command to turn it back

```bash
cd upstream/
patch -R -p1 < ../patches/00-patch.applied
```
