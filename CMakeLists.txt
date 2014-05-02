cmake_minimum_required ( VERSION 2.6 )
set ( CMAKE_CXX_FLAGS "-std=c++11" )

project ( HarbourCraneHelper )

add_subdirectory( OuterWorld )
add_subdirectory( ExpertSystem )
add_subdirectory( ControlInterface )