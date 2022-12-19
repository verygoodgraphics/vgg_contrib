cmake_minimum_required(VERSION 3.19)
project(vgg_contrib_wasmtime)

# Download wastime-c-api if it does not already exist
set(WASMTIME_C_API_DIR "${CMAKE_CURRENT_SOURCE_DIR}/upstream/c-api/")
if(NOT EXISTS "${WASMTIME_C_API_DIR}")
  if (WIN32)
    set(DOWNLOAD_URL "https://github.com/bytecodealliance/wasmtime/releases/download/v3.0.1/wasmtime-v3.0.1-x86_64-windows-c-api.zip")
  elseif (APPLE AND (CMAKE_SYSTEM_PROCESSOR MATCHES "^arm" OR CMAKE_SYSTEM_PROCESSOR MATCHES "^aarch64"))
    set(DOWNLOAD_URL "https://github.com/bytecodealliance/wasmtime/releases/download/v3.0.1/wasmtime-v3.0.1-aarch64-macos-c-api.tar.xz")
  elseif (APPLE)
    set(DOWNLOAD_URL "https://github.com/bytecodealliance/wasmtime/releases/download/v3.0.1/wasmtime-v3.0.1-x86_64-macos-c-api.tar.xz")
  else()
    set(DOWNLOAD_URL "https://github.com/bytecodealliance/wasmtime/releases/download/v3.0.1/wasmtime-v3.0.1-x86_64-linux-c-api.tar.xz")
  endif()

  cmake_path(GET DOWNLOAD_URL FILENAME C_LIB_FILE_NAME) # *.tar.xz, or *.zip
  cmake_path(GET C_LIB_FILE_NAME STEM LAST_ONLY EXTRACTED_C_LIB_DIR_NAME) # remove .xz, or .zip
  if(NOT WIN32)
    cmake_path(GET EXTRACTED_C_LIB_DIR_NAME STEM LAST_ONLY EXTRACTED_C_LIB_DIR_NAME) # remove .tar
  endif()

  set(DOWNLOAD_AT_PATH "${CMAKE_CURRENT_BINARY_DIR}/${C_LIB_FILE_NAME}")
  message(STATUS "Downloading wasmtime-c-api from ${DOWNLOAD_URL}")
  file(DOWNLOAD
    ${DOWNLOAD_URL}
    ${DOWNLOAD_AT_PATH}
    STATUS download_status
    SHOW_PROGRESS)
  if(NOT download_status MATCHES "^0;")
    message(FATAL_ERROR "Downloading wastime-c-api failed with ${download_status}")
  endif()

  file(ARCHIVE_EXTRACT INPUT ${DOWNLOAD_AT_PATH}
    DESTINATION ${CMAKE_CURRENT_SOURCE_DIR})
  file(RENAME "${CMAKE_CURRENT_SOURCE_DIR}/${EXTRACTED_C_LIB_DIR_NAME}" ${WASMTIME_C_API_DIR})
  file(REMOVE ${DOWNLOAD_AT_PATH})
endif()


add_subdirectory(upstream EXCLUDE_FROM_ALL)

set(VGG_CONTRIB_WASMTIME_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream/include CACHE PATH "" FORCE)
mark_as_advanced(VGG_CONTRIB_WASMTIME_INCLUDE)