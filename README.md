# VGG Contrib

This repo holds third-party libraries used in VGG projects.

All libraries should adhere to the following three rules:

- **Inclusion Rule:** Source-code only, no binaries, no submodules, no fetching scripts. Just code.
  - If the library is header-only, then a pre-built single-header file is prefered.
  - Otherwise the whole library directory is included.
- **Depedency Rule:** Dependencies of a library should be flattened out as other libraries in this repo.
- **Patching Rule:** The original code lies in the `upstream` directory, **with modifications** if neccessary. The modifications to the original code are kept in the `patches` directory.

## Library List

| Name                                            | License                                                      | Upstream                                   | Patched | Category    | Inclusion Type |
| ----------------------------------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ | ----------------------------------------------- | ----------- | -------------- |
| [argparse](https://github.com/p-ranav/argparse) | MIT | [557948](https://github.com/p-ranav/argparse/tree/557948f1236db9e27089959de837cc23de6c6bbd) | No | common | Single file |
| [boost](https://www.boost.org/) | [Boost](https://www.boost.org/users/license.html) | [1.80.0](https://www.boost.org/users/history/version_1_80_0.html) | No | common | Directory (partial) |
| [rxcpp](https://github.com/ReactiveX/RxCpp) | Apache-2.0 | [4.1.1](https://github.com/ReactiveX/RxCpp/tree/v4.1.1) | No | common | Directory (partial) |
| [json](https://github.com/nlohmann/json)        | MIT                                                          | [3.11.2](https://github.com/nlohmann/json/releases/tag/v3.11.2) | No | json        | Single file |
| [valijson](https://github.com/tristanpenman/valijson) | BSD | [feature-vgg](https://github.com/verygoodgraphics/valijson/tree/feature-vgg) | No | json | Single file |
| [picosha2](https://github.com/okdshin/PicoSHA2) | MIT                                                          | [7bfa26](https://github.com/okdshin/PicoSHA2/tree/7bfa26156981f7181f240906495a2c33c7fa48be) | No | hashing     | Single file |
| [sdefl/sinfl](https://github.com/vurtun/lib)    | MIT/Public Domain                                            | [71382a](https://github.com/vurtun/lib/tree/71382a1d14dad58219e7f6634d2381fa30dab175) | Yes | compression | Single file(s) |
| [zlib](https://github.com/madler/zlib)          | [ZLIB](https://github.com/madler/zlib/blob/master/LICENSE) | [1.2.13](https://github.com/madler/zlib/releases/tag/v1.2.13) | Yes | compression | Directory     |
| [zstd](https://github.com/facebook/zstd)        | BSD/GPLv2                                                    | [1.5.2](https://github.com/facebook/zstd/releases/tag/v1.5.2) | No | compression | Directory |
| [zip](https://github.com/kuba--/zip) | [UNLICENSE](https://github.com/kuba--/zip/blob/master/UNLICENSE) | [0.2.6](https://github.com/kuba--/zip/releases/tag/v0.2.6) | No | compression | Directory |
| [libpng](https://sourceforge.net/projects/libpng/) | [PNG Reference Library License](http://www.libpng.org/pub/png/src/libpng-LICENSE.txt) | [1.6.38](https://sourceforge.net/projects/libpng/files/libpng16/1.6.38/) | No | image       | Directory |
| [libjpeg-turbo](https://github.com/libjpeg-turbo/libjpeg-turbo) | [Mixed](https://github.com/libjpeg-turbo/libjpeg-turbo/blob/main/LICENSE.md) | [2.1.4](https://github.com/libjpeg-turbo/libjpeg-turbo/releases/tag/2.1.4) | Yes | image | Directory |
| [libwebp](https://github.com/webmproject/libwebp) | BSD | [1.2.4](https://github.com/webmproject/libwebp/releases/tag/v1.2.4) | No | image | Directory |
| [nanobind](https://github.com/wjakob/nanobind) | BSD-3-Clause | [1.6.2](https://github.com/wjakob/nanobind/releases/tag/v1.6.2) | No | binding | Directory |
| [glm](https://github.com/g-truc/glm) | [Mixed](https://github.com/g-truc/glm/blob/master/manual.md#section0) | [0.9.9.8](https://github.com/g-truc/glm/releases/tag/0.9.9.8) | No | algorithm | Directory |
| [yoga](https://github.com/facebook/yoga) | MIT | [efd27ef](https://github.com/facebook/yoga/commit/efd27efd70ba298db618973a1d2d5f89e1b74d34) | Yes | algorithm | Directory |
| [rapidfuzz-cpp](https://github.com/maxbachmann/rapidfuzz-cpp) | MIT | [2.0.0](https://github.com/maxbachmann/rapidfuzz-cpp/releases/tag/v2.0.0) | No | algorithm | Directory |
| [bezier](https://github.com/oysteinmyrmo/bezier) | MIT | [0.2.1](https://github.com/oysteinmyrmo/bezier/tree/v0.2.1) | NO | algorithm | Single file |

If you encounter compiling issues for boost, please refer to boost's [README](./boost/README.md).

## How to use

### 1. Get `vgg_contrib`

You could download its latest code copy [here](https://github.com/verygoodgraphics/vgg_contrib/archive/refs/heads/master.zip), or clone it using git

```
git clone https://github.com/verygoodgraphics/vgg_contrib.git
```

### 2. Put it in the right place

Put `vgg_contrib` in your project where you can access it.

### 3. Choose any library you'd like to use

Pick a library and write cmake commands to use it. Please check out the full list in the usage summary section below.

```cmake
#
# example 1: zlib
#
if(NOT VGG_CONTRIB_ZLIB_INCLUDE OR VGG_CONTRIB_ZLIB_INCLUDE STREQUAL "")
  add_subdirectory(path_to_your/vgg_contrib/zlib)
endif()
target_include_directories(your_target PRIVATE ${VGG_CONTRIB_ZLIB_INCLUDE} ${VGG_CONTRIB_ZLIB_CONF_INCLUDE})
target_link_libraries(your_target zlib)

#
# example 2: json
#
if (NOT VGG_CONTRIB_JSON_INCLUDE OR VGG_CONTRIB_JSON_INCLUDE STREQUAL "")
  add_subdirectory(path_to_your/vgg_contrib/zlib)
endif()
target_include_directories(your_target PRIVATE ${VGG_CONTRIB_JSON_INCLUDE})

#
# example 3: nanobind
#
if (NOT VGG_CONTRIB_NANOBIND_INCLUDE OR VGG_CONTRIB_NANOBIND_INCLUDE STREQUAL "")
  add_subdirectory(path_to_your/vgg_contrib/nanobind)
endif()
nanobind_add_module(your_target ${YOUR_TARGET_SRCS}) # use nanobind's macro to add target
target_include_directories(your_target PRIVATE ${VGG_CONTRIB_NANOBIND_INCLUDE}) # this is totally optional
```

If you put `vgg_contrib` outside of your current CMakeLists.txt directory, you should give explicitly the binary directory like this
```cmake
add_subdirectory(path_to_your/vgg_contrib/zlib ${CMAKE_BINARY_DIR}/vgg_contrib/zlib)
```

### A. Library usage summary

| Name          | Include Path                                                 | Link Target                                                  |
| ------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| argparse      | `VGG_CONTRIB_ARGPARSE_INCLUDE`                               | N/A                                                          |
| boost         | `VGG_CONTRIB_BOOST_INCLUDE`                                  | static libs, see boost's [README](./boost/README.md)         |
| rxcpp         | `VGG_CONTRIB_RXCPP_INCLUDE`                                  | N/A                                                          |
| json          | `VGG_CONTRIB_JSON_INCLUDE`                                   | N/A                                                          |
| valijson      | `VGG_CONTRIB_VALIJSON_INCLUDE`                               | N/A                                                          |
| picosha2      | `VGG_CONTRIB_PICOSHA2_INCLUDE`                               | N/A                                                          |
| sdefl/sinfl   | `VGG_CONTRIB_SDEFL_INCLUDE`                                  | N/A                                                          |
| zlib          | `VGG_CONTRIB_ZLIB_INCLUDE`<br />`VGG_CONTRIB_ZLIB_CONF_INCLUDE` | shared: `zlib`, static: `zlibstatic`                         |
| zstd          | `VGG_CONTRIB_ZSTD_INCLUDE`                                   | shared: `libzstd_shared`, static: `libzstd_static`           |
| zip           | `VGG_CONTRIB_ZIP_INCLUDE`                                    | static: `zip`                                                |
| libpng        | `VGG_CONTRIB_LIBPNG_INCLUDE`<br />`VGG_CONTRIB_LIBPNG_CONF_INCLUDE` | shared: `png`, static: `png_static`                          |
| libjpeg-turbo | `VGG_CONTRIB_LIBJPG_INCLUDE`<br />`VGG_CONTRIB_LIBJPG_CONF_INCLUDE` | shared: `jpeg`, static: `jpeg-static`                        |
| libwebp       | `VGG_CONTRIB_LIBWEBP_INCLUDE`<br />`VGG_CONTRIB_LIBWEBP_CONF_INCLUDE` | static: `webp`                                               |
| nanobind      | `VGG_CONTRIB_NANOBIND_INCLUDE`                               | [N/A (implicitly added by `nanobind_add_module`)](https://nanobind.readthedocs.io/en/latest/building.html#building-an-extension) |
| glm           | `VGG_CONTRIB_GLM_INCLUDE`                                    | N/A                                                          |
| yoga          | `VGG_CONTRIB_YOGA_INCLUDE`                                   | static: `yogacore`                                           |
| rapidfuzz-cpp | `VGG_CONTRIB_RAPIDFUZZCPP_INCLUDE`                           | N/A                                                          |
| bezier        | `VGG_CONTRIB_BEZIER_INCLUDE`                                 | N/A                                                          |

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

And don't forget to update  `README.md` in the root directory.

### Contribution Tip 1: Make sure to add all files

When adding third-party source code in upstream folder, it is highly possible that some files are not added to the git version control because of rules in `.gitignore` in its directories. To list all files that is not added, use the command to find out

```bash
git clean -fdnx
```

and decide whether or not to forcibly add those missing files using `git add -f`. Look out!

### Contribution Tip 2: About patching

Sometimes it is neccessary to patch the library source code to meet our needs, and it is a good practice to keep track of the changes in patch files. For example, if the upstream got updated, we could just re-patch the code effortlessly.

In this project, we assume all the code in `upstream` directory is already patched so that we could use it at ease.

#### How to make a patch

Take the `sdefl` library for example. Say we have made changes to `upstream/sinfl.h` **in place**, and the original code have been copied as the `original` folder. We could use the following command to make a new patch

```bash
diff -ru original/ upstream/ > patches/00-patch.applied
```

#### How to apply a patch

If we update the `sinfl.h` to the latest upstream version, un-patched, we could use the following command to re-patch this file

```bash
cd upstream/
patch -p1 < ../patches/00-patch.applied
```

#### How to revert a patch

If we need to use the original `sinfl.h`, we use the following command to turn it back

```bash
cd upstream/
patch -R -p1 < ../patches/00-patch.applied
```
