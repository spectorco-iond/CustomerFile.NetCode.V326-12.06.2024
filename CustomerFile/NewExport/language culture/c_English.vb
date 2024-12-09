Public Class c_English

#Region "##########Public Properties######################"
    Public ReadOnly Property PROG_QUOTE As String
        Get
            PROG_QUOTE = "QUOTE PRICING FORM"
        End Get
    End Property
    Public ReadOnly Property PROG_PROGRAM As String
        Get
            PROG_PROGRAM = "PROGRAM PRICING FORM"
        End Get
    End Property
    Public ReadOnly Property PROG_SP As String
        Get
            PROG_SP = "SPECIAL PRICING FORM"
        End Get
    End Property
    Public ReadOnly Property HEADER_MESS_PROG As String
        Get
            HEADER_MESS_PROG = "Thank you for including our products in your program.Please reference the supplier program number on your P.O. Please note the comments below for additional important."
        End Get
    End Property
    Public ReadOnly Property HEADER_MESS_SP As String
        Get
            HEADER_MESS_SP = "Thank you for including our products in your special pricing Please reference the supplier special pricing number on your P.O. Please note the comments below for additional important."
        End Get
    End Property
    Public ReadOnly Property HEADER_MESS_QUOTE As String
        Get
            HEADER_MESS_QUOTE = "Thank you for including our products in your quote Please reference the supplier special quote on your P.O. Please note the comments below for additional important information."
        End Get
    End Property
    Public ReadOnly Property CUSTOMER As String
        Get
            CUSTOMER = "CUSTOMER#:"
        End Get
    End Property
    Public ReadOnly Property PROGRAM As String
        Get
            PROGRAM = "PROGRAM:"
        End Get
    End Property
    Public ReadOnly Property QUOTE As String
        Get
            QUOTE = "QUOTE:"
        End Get
    End Property
    Public ReadOnly Property ADDRESS As String
        Get
            ADDRESS = "ADDRESS:"
        End Get
    End Property
    Public ReadOnly Property PROGRAM_DATE As String
        Get
            PROGRAM_DATE = "PROGRAM DATE:"
        End Get
    End Property
    Public ReadOnly Property QUOTE_DATE As String
        Get
            QUOTE_DATE = "QUOTE DATE:"
        End Get
    End Property
    Public ReadOnly Property IMPRINT As String
        Get
            IMPRINT = "IMPRINT:"
        End Get
    End Property
    Public ReadOnly Property PROG_START_DATE As String
        Get
            PROG_START_DATE = "PROGRAM START DATE:"
        End Get
    End Property
    Public ReadOnly Property QUOTE_START_DATE As String
        Get
            QUOTE_START_DATE = "QUOTE START DATE:"
        End Get
    End Property
    Public ReadOnly Property PROG_END_DATE As String
        Get
            PROG_END_DATE = "PROGRAM END DATE:"
        End Get
    End Property
    Public ReadOnly Property QUOTE_END_DATE As String
        Get
            QUOTE_END_DATE = "QUOTE END DATE:"
        End Get
    End Property
    Public ReadOnly Property CONTACT As String
        Get
            CONTACT = "CONTACT:"
        End Get
    End Property
    Public ReadOnly Property PHONE As String
        Get
            PHONE = "PHONE:"
        End Get
    End Property
    Public ReadOnly Property SPECTOR_CONTACT As String
        Get
            SPECTOR_CONTACT = "SPECTOR CONTACT:"
        End Get
    End Property
    Public ReadOnly Property EMAIL As String
        Get
            EMAIL = "EMAIL:"
        End Get
    End Property
    Public ReadOnly Property SPECTOR_EMAIL As String
        Get
            SPECTOR_EMAIL = "SPECTOR EMAIL:"
        End Get
    End Property
    '---------------Content Property-------------------
    Public ReadOnly Property CODE As String
        Get
            CODE = "CODE:"
        End Get
    End Property
    Public ReadOnly Property COLOR As String
        Get
            COLOR = "COLOR:"
        End Get
    End Property
    Public ReadOnly Property DECORATION As String
        Get
            DECORATION = "DECORATION:"
        End Get
    End Property
    Public ReadOnly Property PACKAGING As String
        Get
            PACKAGING = "PACKAGING:"
        End Get
    End Property
    Public ReadOnly Property SHIPPING As String
        Get
            SHIPPING = "SHIPPING:"
        End Get
    End Property
    Public ReadOnly Property TYPE As String
        Get
            TYPE = "TYPE:"
        End Get
    End Property
    Public ReadOnly Property SETUP As String
        Get
            SETUP = "SETUP:"
        End Get
    End Property
    Public ReadOnly Property COMMENT As String
        Get
            COMMENT = "COMMENTS:"
        End Get
    End Property
    '-------PRICING IN THE CONTENT--------- 
    Public ReadOnly Property PRICING As String
        Get
            PRICING = "PRICING"
        End Get
    End Property
    Public ReadOnly Property EQP As String
        Get
            EQP = "EQP %"
        End Get
    End Property
    Public ReadOnly Property QUANTITY As String
        Get
            QUANTITY = "QUANTITY"
        End Get
    End Property
    Public ReadOnly Property PRICE As String
        Get
            PRICE = "PRICE"
        End Get
    End Property
    Public ReadOnly Property SUBTOTAL As String
        Get
            SUBTOTAL = "SUBTOTAL"
        End Get
    End Property
    Public ReadOnly Property RUN_CHARGE As String
        Get
            RUN_CHARGE = "RUN CHARGE"
        End Get
    End Property
    Public ReadOnly Property SETUP_PRICE As String
        Get
            SETUP_PRICE = "SETUP PRICE"
        End Get
    End Property
    Public ReadOnly Property FOODER_MESS_QUOTE As String
        Get
            FOODER_MESS_QUOTE = "***THIS QUOTE IS VALID FOR 2 WEEKS***" + Chr(10) + "Please note that all prices quoted are subject To change due To the additional tariffs proposed by Section 301.Once the final list Of affected items Is published we will inform you Of changes To pricing, should it apply."
            'vbCr Chr(10) vbLf     Chr(13)    vbCrLf             Chr(13) + Chr(10)                
        End Get
    End Property
    Public ReadOnly Property FOODER_MESS_PROG As String
        Get
            FOODER_MESS_PROG = "***PROGRAM PRICING FORM***"
        End Get
    End Property

#End Region
End Class
