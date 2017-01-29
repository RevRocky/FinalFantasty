"""This module creates card images for Final Fantasty in a modular fashion using a dictionary that has been
read from an excel file containing information about the cards. It uses the Pillow library to do some simple text
and image overlay!

Version 0.1

Author: Rocky Petkov"""


from PIL import ImageDraw, Image, ImageFont
import os
import copy


# Below are some global constants regarding different colours, fonts and file locations to be used with this module.
# Please do not tamper with these constants with out the express approval of the author.

CARD_ART_DIRECTORY = ".." + os.sep + ".." + os.sep + "Art"                 # Path to Card Art!
CARD_DIRECTORY = ".." + os.sep + ".." + os.sep + "Art" + os.sep + "Cards"  # Path to Final Card Images

CARD_FONT = ImageFont.truetype("Bitter-Regular.otf", size=28)
CARD_FONT_BOLD = ImageFont.truetype("Bitter-Bold.otf", size=50)
CARD_FONT_ITALIC = ImageFont.truetype("Bitter-Italic.otf", size=28)

BLACK = (0, 0, 0)


PICTURE_TOP_LEFT = (80, 77)                                                # Top left corner of the picture area
PICTURE_SIZE = (576, 577)                                                  # Size of picture area
NAME_LOCATION = (368, 701)                                                 # Boundaries of card name
NAME_BOUNDARIES = (515, 70)                                                # Size of card area alotted to name
TYPE_BOUNDARIES = ((0, 0), (0, 0), (0, 0), (0, 0))                         # Boundaries of card type descriptors
DESCRIPTION_BOUNDARIES = ((0, 0), (0, 0), (0, 0), (0, 0))                  # Boundaries of Mechanic Description
PICTOGRAMME_BOUNDARIES = ((0, 0), (0, 0), (0, 0), (0, 0))                  # Boundaries of where the stats are

"Simple little function. Loops around and makes images for all of the cards!"
def create_pictures(card_list):
    for card in card_list:
        construct_card_image(card)

"""Creates a PNG image for the card described by the dictionary card_description and returns that image
to the calling environment"""
def construct_card_image(card_description):
    # Opening our images
    card_template = Image.open(".." + os.sep + ".." + os.sep + "Sketches" + os.sep + "CardTemplateTEST.png", 'r')
    card_art = Image.open(CARD_ART_DIRECTORY + os.sep + card_description["Type"] + os.sep +
                          card_description["Art"], 'r')
    card_image = overlay_image(card_template, card_art, PICTURE_TOP_LEFT)    # Overlay the card art on to template

    # Now we overlay the title on the image
    image_draw = ImageDraw.Draw(card_image)
    resized_font, width, null = fit_text(NAME_BOUNDARIES, CARD_FONT_BOLD, card_description["Name"], image_draw)
    centered_top_left = (NAME_LOCATION[0] - (width/2), NAME_LOCATION[1])

    image_draw.multiline_text(xy=centered_top_left, text=card_description["Name"].upper(), font=resized_font,
                                fill=BLACK, align="left")
    card_image.show()




"""The following function uses Pillow to overlay a foreground image overtop of a background image
The foreground image must be smaller than the background image Location in this case is an (X, Y) tuple
describing the location ofv where the centre of the new image shall be"""
def overlay_image(background_image, foreground_image, location):
    # Check to ensure the foreground image is of correct size. If it is not resize it.
    if (foreground_image.width != PICTURE_SIZE[0]) or (foreground_image.height != PICTURE_SIZE[1]):
        foreground_image = foreground_image.resize(PICTURE_SIZE)

    # We must do two quick conversions to ensure that the paste will work correctly and tere will be no artefacts
    # TODO put this into a conditional
    background_image = background_image.convert(mode="RGB")             # Gettting rid of transparency on template
    foreground_image = foreground_image.convert(mode="RGBA")            # Ensuring the image has an alpha channel

    background_image.paste(foreground_image, PICTURE_TOP_LEFT, foreground_image)
    return background_image


"""Scales down a font until a message will fit in the desired area. The image_draw object must be supplied as well
Returns:

    font - a font object with an altered size. This is a modified deep copy of the original, so there will be no
    unintended sideeffects
    width, height - The width and height of the text block, used in aligning text"""
def fit_text(area, font, message, image):
    new_font = clone_font(font)                                 # Cloning the font so we can safely rescale
    width, height = image.textsize(message.upper(), new_font)   # Calculating size of the message
    while width > area[0] and height > area[1]:
        new_font.size -= 5                                         # 5 Seems like a good thing to decrement by
        width, height = image.textsize(message.upper(), new_font)  # Calculating size of font
    return new_font, width, height

"Returns a clone of the TrueType or OpenType font supplied"
def clone_font(font):
    return ImageFont.truetype(font.path, font.size)

