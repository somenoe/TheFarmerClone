import os
import sys
from PIL import Image

def crop_image(image_path, aspect_ratio=(10, 7)):
    """
    Crops an image from the center to a specific aspect ratio.
    The cropped image is saved in the same directory with '_cropped' suffix.
    """
    if not os.path.isfile(image_path):
        print(f"Error: File not found at '{image_path}'")
        return

    try:
        with Image.open(image_path) as img:
            original_width, original_height = img.size
            print(f"Original image size: {original_width}x{original_height}")

            target_aspect = aspect_ratio[0] / aspect_ratio[1]
            image_aspect = original_width / original_height

            if image_aspect > target_aspect:
                # Image is wider than target, crop width
                new_width = int(target_aspect * original_height)
                new_height = original_height
                left = (original_width - new_width) / 2
                top = 0
                right = left + new_width
                bottom = new_height
            else:
                # Image is taller than target, crop height
                new_width = original_width
                new_height = int(original_width / target_aspect)
                left = 0
                top = (original_height - new_height) / 2
                right = new_width
                bottom = top + new_height

            box = (left, top, right, bottom)
            cropped_img = img.crop(box)
            
            print(f"Cropping to: {cropped_img.width}x{cropped_img.height}")

            directory, filename = os.path.split(image_path)
            name, ext = os.path.splitext(filename)
            new_filename = f"{name}_cropped{ext}"
            new_image_path = os.path.join(directory, new_filename)

            cropped_img.save(new_image_path)
            print(f"Saved cropped image to: '{new_image_path}'")

    except Exception as e:
        print(f"An error occurred: {e}")

if __name__ == "__main__":
    if len(sys.argv) < 2:
        print("Usage: python crop.py <path_to_image>")
    else:
        crop_image(sys.argv[1])