cmake_minimum_required(VERSION 3.7)

project(vgg_contrib_quickjs)
set(QJS_SRCS
  upstream/quickjs/quickjs.c
  upstream/quickjs/libregexp.c
  upstream/quickjs/libunicode.c
  upstream/quickjs/cutils.c
  upstream/quickjs/quickjs-libc.c
  upstream/quickjs/libbf.c
)

if(MSVC)
  add_compile_options(/wd"4267" /wd"4244" /wd"4018" 
    /wd"4101" /wd"4146" /wd"4013" /wd"4334" /wd"4996")
endif()

add_library(quickjs STATIC ${QJS_SRCS})
target_compile_options(quickjs PRIVATE
  -D_GNU_SOURCE
  -DCONFIG_VERSION="2021-03-27"
  -DCONFIG_BIGNUM
  -DDUMP_LEAKS
)

if (APPLE)
target_compile_options(quickjs PRIVATE
  -Wno-incompatible-pointer-types-discards-qualifiers
)
elseif(NOT MSVC)
target_compile_options(quickjs PRIVATE
  -Wno-discarded-qualifiers 
  -Wno-unused-result
)
endif()

if(MSVC)
  target_compile_definitions(quickjs PRIVATE JS_STRICT_NAN_BOXING)
endif()

set(VGG_CONTRIB_QUICKJS_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream CACHE PATH "" FORCE)
mark_as_advanced(VGG_CONTRIB_QUICKJS_INCLUDE)