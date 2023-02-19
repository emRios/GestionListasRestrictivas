function imprimirPdfLR(id) {

    var vlogo = 'data:image/png;base64,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';

	console.log(id)

    var def_rptLR = {
        pageSize: 'LETTER',
        defaultStyle: {
            font: 'Roboto'
        },
        "content": [
            {
                "text": [
                    {
                        "text": "ANEXO FALSOS POSITIVOS" + id,
                        "nodeName": "STRONG",
                        "bold": true,
                        "style": [
                            "html-strong",
                            "html-p"
                        ]
                    }
                ],
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "SCORE:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "File:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "Source Date:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "Entity Name:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "Best Name:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "Best Country:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "Adress:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "Country:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "City:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "State:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "Street1:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "Street2:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "Postal Code:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "Comments:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "Aka:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "Aka:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "Source:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "Offence:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "Category:",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": "National ID (Cédula):",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": " ",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": " ",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            },
            {
                "text": " "
            },
            {
                "text": " ",
                "nodeName": "P",
                "margin": [
                    0,
                    5,
                    0,
                    10
                ],
                "style": [
                    "html-p"
                ]
            }
        ],
        "styles": {
            "green": {
                "color": "green"
            }
        }
    }

    pdfMake.createPdf(def_rptLR).open();
}