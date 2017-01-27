"""This module creates card images for Final Fantasty in a modular fashion using a dictionary that has been
read from an excel file containing information about the cards. It uses the Pillow library to do some simple text
and image overlay!

Version 0.1

Author: Rocky Petkov"""


from PIL import ImageDraw, Image
import os


# Below are some global constants regarding different colours, fonts and file locations to be used with this module.
# Please do not tamper with these constants with out the express approval of the author.

CARD_ART_DIRECTORY = ".." + os.sep + ".." + os.sep + "Art"                 # Path to Card Art!
CARD_DIRECTORY = ".." + os.sep + ".." + os.sep + "Art" + os.sep + "Cards"  # Path to Final Card Images

PICTURE_TOP_LEFT = (80, 77)                                                # Top left corner of the picture area
PICTURE_SIZE = (576, 577)                                                  # Size of picture area
NAME_BOUNDARIES = ((0, 0), (0, 0), (0, 0), (0, 0))                         # Boundaries of card name
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
    card_image.save(card_description["Picture Location"] + ".png", "PNG")



"""The following function uses Pillow to overlay a foreground image overtop of a background image
The foreground image must be smaller than the background image Location in this case is an (X, Y) tuple
describing the location ofv where the centre of the new image shall be"""
def overlay_image(background_image, foreground_image, location):

    # Check to ensure the foreground image is of correct size. If it is not resize it.
    if (foreground_image.width != PICTURE_SIZE[0]) or (foreground_image.height != PICTURE_SIZE[1]):
        foreground_image = foreground_image.resize(PICTURE_SIZE)
    background_image.paste(foreground_image, PICTURE_TOP_LEFT)
    return background_image.convert(mode="RGBA")



