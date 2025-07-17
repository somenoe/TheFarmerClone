import os
import sys
from PIL import Image

def resize_image(image_path, max_size=2048):
    """
    Resizes an image if its width or height is larger than max_size,
    maintaining the aspect ratio.
    The resized image is saved in the same directory with '_resized' suffix.
    """
    if not os.path.isfile(image_path):
        print(f"Error: File not found at '{image_path}'")
        return

    try:
        with Image.open(image_path) as img:
            width, height = img.size
            print(f"Original image size: {width}x{height}")

            if width > max_size or height > max_size:
                ratio = min(max_size / width, max_size / height)
                new_width = int(width * ratio)
                new_height = int(height * ratio)

                print(f"Resizing to: {new_width}x{new_height}")
                resized_img = img.resize((new_width, new_height), Image.Resampling.LANCZOS)

                directory, filename = os.path.split(image_path)
                name, ext = os.path.splitext(filename)
                new_filename = f"{name}_resized{ext}"
                new_image_path = os.path.join(directory, new_filename)

                resized_img.save(new_image_path)
                print(f"Saved resized image to: '{new_image_path}'")
            else:
                print("Image is already within the size limit. No resizing needed.")

    except Exception as e:
        print(f"An error occurred: {e}")

if __name__ == "__main__":
    if len(sys.argv) < 2:
        print("Usage: python resize.py <path_to_image>")
    else:
        resize_image(sys.argv[1])
