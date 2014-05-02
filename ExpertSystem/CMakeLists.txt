cmake_minimum_required ( VERSION 2.6 )
set ( CMAKE_CXX_FLAGS "-std=c++11" )

project ( ExpertSystem )
set ( LIB_NAME ExpertSystem )
set ( LIB_TYPE STATIC )

set( CMAKE_BUILD_TYPE RELEASE )

include_directories ( ${PROJECT_SOURCE_DIR}/include )

set ( SOURCE ${PROJECT_SOURCE_DIR}/src/expertsystem.cpp )

add_library( ${LIB_NAME} ${LIB_TYPE} ${SOURCE} )