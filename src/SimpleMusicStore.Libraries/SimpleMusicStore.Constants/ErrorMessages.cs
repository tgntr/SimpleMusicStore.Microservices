using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Constants
{
    public static class ErrorMessages
    {
        public const string
            UNSUPPORTED_SORT = "Unsupported sort type!",
            PRICE_LIMIT = "Price must be between 1$ and 100$!",
            INVALID_ADDRESS = "Invalid address!",
            EMPTY_CART = "Cart is empty!",
            RECORD_ALREADY_IN_WISHLIST = "Record is already in wishlist!",
            INVALID_RECORD = "Record does not exist!",
            ARTIST_ALREADY_FOLLOWED = "Artist is already followed!",
            INVALID_ARTIST = "Artist does not exist!",
            LABEL_ALREADY_FOLLOWED = "Label is already followed!",
            INVALID_LABEL = "Label does not exist!",
            RECORD_NOT_IN_WISHLIST = "Record is not in wishlist!",
            ARTIST_NOT_FOLLOWED = "Artist is not followed!",
            LABEL_NOT_FOLLOWED = "Label is not followed!",
            RECORD_ALREADY_EXISTS = "Record is already in store!",
            ITEM_NOT_IN_CART = "Cart does not contain such record!",
            UNAVAILABLE_QUANTITY = "Required quantity is not available!",
            INVALID_CREDENTIALS = "Invalid credentials!",
            INVALID_ORDER = "Invalid order!",
            INVALID_SEARCH_TERM = "Search term must not be empty!",
            INVALID_FILE = "Track preview must be non-empty MP3 file",
            INVALID_DISCOGS_URL = "Invalid discogs URL!",
            INVALID_USER = "User does not exist!",
            INACCESSIBLE = "Requested information is inaccessible!",
            INVALID_COMMENT = "The comment does not exist!",
            FORBIDDEN_COMMENT_DELETION = "You cannot delete this comment!",
            FORBIDDEN_COMMENT_EDIT = "You cannot edit this comment.", 
            INVALID_TOKEN = "Invalid token!";
    }
}
