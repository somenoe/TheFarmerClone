
@echo off
REM Professional batch script for image processing
REM Usage: temp.bg.bat <filename_without_extension>

setlocal
if "%~1"=="" (
    echo Error: No filename provided.
    echo Usage: %~nx0 ^<filename_without_extension^>
    exit /b 1
)

set "IMG=%~1"
set "IMG_NEW_PATH=TheFarmerCloneContent\%IMG%.png"
set "IMG_ORIGINAL=TheFarmerCloneContent\temp_screenshots\%IMG%.png"
set "IMG_RESIZED=TheFarmerCloneContent\temp_screenshots\%IMG%_resized.png"
set "IMG_CROPPED=TheFarmerCloneContent\temp_screenshots\%IMG%_resized_cropped.png"

REM Resize image
python script/resize.py "%IMG_ORIGINAL%"
if errorlevel 1 (
    echo Error: resize.py failed.
    exit /b 1
)

REM Crop image
python script/crop.py "%IMG_RESIZED%"
if errorlevel 1 (
    echo Error: crop.py failed.
    exit /b 1
)

REM Move cropped image to original name
move "%IMG_CROPPED%" "%IMG_NEW_PATH%" >nul

echo Processing complete for %IMG%.
endlocal