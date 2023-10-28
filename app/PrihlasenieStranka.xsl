<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:my="http://example.com/PrihlasenieSchema.xsd">
<xsl:output method="html"/>

<xsl:template match="/my:reg_formular">
<style type = "text/css">
    body {
        margin: 0;
        font-family: var(--bs-body-font-family);
        font-size: var(--bs-body-font-size);
        font-weight: var(--bs-body-font-weight);
        line-height: var(--bs-body-line-height);
        color: var(--bs-body-color);
        text-align: var(--bs-body-text-align);
        background-color: var(--bs-body-bg);
        -webkit-text-size-adjust: 100%;
        -webkit-tap-highlight-color: transparent;
    }
    
    
    .h1, .h2, .h3, .h4, .h5, .h6, h1, h2, h3, h4, h5, h6 {
        margin-top: 0;
        margin-bottom: 0.5rem;
        font-weight: 500;
        line-height: 1.2;
    }
    h1 {
        display: block;
        font-size: 2em;
        margin-block-start: 0.67em;
        margin-block-end: 0.67em;
        margin-inline-start: 0px;
        margin-inline-end: 0px;
        font-weight: bold;
    }
.container, .container-fluid, .container-lg, .container-md, .container-sm, .container-xl, .container-xxl {
    width: 100%;
    padding-right: var(--bs-gutter-x,.75rem);
    padding-left: var(--bs-gutter-x,.75rem);
    margin-right: auto;
    margin-left: auto;
}
    /* Apply margin and padding to the form group */
    .form-group {
        margin-bottom: 15px;
    }
    
    /* Style the label within the form group */
    .form-group label {
        font-weight: bold;
    }
    
    /* Apply spacing to the form controls within the form group */
    .form-group .form-control {
        margin-top: 5px;
        padding: 10px;
        border: 1px solid #ccc;
        border-radius: 4px;
        width: 100%;
    }
    
    /* Style text area within the form group */
    .form-group textarea {
        min-height: 100px; /* Adjust the height as needed */
    }
    
    /* Style checkboxes and radio buttons */
    .form-group .form-check {
        margin-top: 5px;
    }
    
    /* Style required field labels */
    .form-group label.required::after {
        content: " *";
        color: red;
    }
    
    /* Style error messages for form controls */
    .form-group .error-message {
        color: red;
        font-size: 12px;
    }

    /* Custom styles */
    .container mt-5 {
      max-width: 1200px; /* Customize the container width */
      margin: 0 auto; /* Center the container */
      padding: 20px; /* Add padding to the container */
      margin-top: 3rem; /* Customize the top margin */
    }
    form input {
    height: 40px; /* Adjust the height as needed */
    }

    .text-center {
        text-align: center; /* Center-align text or elements */
      }
    .pb-3 {
        padding-bottom: 1rem!important;
    }
    *, ::after, ::before {
        box-sizing: border-box;
    }
    main {
        display: block;
    }
    
    .btn-primary {
        color: #fff;
        background-color: #0d6efd;
        border-color: #0d6efd;
    }



</style>
<html>
    <body>
    <xsl:for-each select = "/my:reg_formular/my:pes">
    <main class = "container">
        <div class="text-center">
            <h1>Prihlásenie psa do evidencie</h1>
            <hr/>
        </div>

    
        
        <div class="container mt-5">
            <form method="post">
                <h2>Osobné údaje:</h2>
                <xsl:for-each select = "/my:reg_formular/my:pes/my:osoba">
                <div class="person" id="person">
                    <div class="form-group" id="clone">
                        <label for="meno">Obchodné meno / meno a priezvisko vlastníka ( držiteľa ) psa:</label>
                        <input type="text" class="form-control" id="meno" name="meno" disabled="disabled"> 
                            <xsl:attribute name="value">
                            <xsl:value-of select="my:meno"/>
                          </xsl:attribute> </input>
                    </div>
        
                    <div class="form-group">
                        <label for="adresa">Sídlo / trvalý pobyt vlastníka ( držiteľa ) psa:</label>
                        <input type="text" class="form-control" id="adresa" name="adresa" disabled="disabled">
                            <xsl:attribute name="value">
                            <xsl:value-of select="my:adresa"/>
                          </xsl:attribute> </input>
                    </div>
        
                    <div class="form-group">
                        <label for="rodne_cislo">IČO /Rod. číslo vlastníka ( držiteľa ) psa:</label>
                        <input type="text" class="form-control" id="rodne_cislo" name="rodne_cislo" disabled="disabled">
                            <xsl:attribute name="value">
                            <xsl:value-of select="my:rodne_cislo"/>
                          </xsl:attribute> </input>
                    </div>
                    <div class="form-group">
                        <label for="kontakt">Kontakt (Tel.číslo / email ):</label>
                        <input type="text" class="form-control" id="kontakt" name="kontakt" disabled="disabled" >
                            <xsl:attribute name="value">
                            <xsl:value-of select="my:kontakt"/>
                          </xsl:attribute> </input>
                    </div>
                    <hr/>
                </div>
            </xsl:for-each>

                
        
        
                <div class="form-group">
                    <label for="zariadenie">Umiestnenie chovného priestoru alebo zariadenia na chov, v ktorom sa pes
                        zdržiava*</label>
                    <input type="text" class="form-control" id="zariadenie" name="zariadenie" disabled="disabled">
                        <xsl:attribute name="value">
                            <xsl:value-of select="my:zariadenie"/>
                          </xsl:attribute> </input>
                </div>
        
                <div class="form-group">
                    <label for="narodenie_psa">Dátum narodenia psa:</label>
                    <input type="date" class="form-control" id="narodenie_psa" name="narodenie_psa" disabled="disabled">
                        <xsl:attribute name="value">
                            <xsl:value-of select="my:narodenie_psa"/>
                          </xsl:attribute> </input>
                </div>
        
                <div class="form-group">
                    <label for="drzba_psa">Dátum, odkedy je pes držaný na území mestskej časti:</label>
                    <input type="date" class="form-control" id="drzba_psa" name="drzba_psa" disabled="disabled" >
                        <xsl:attribute name="value">
                            <xsl:value-of select="my:drzba_psa"/>
                          </xsl:attribute> </input>
                </div>
        
                <div class="form-group">
                    <label for="meno_psa">Meno psa:</label>
                    <input type="text" class="form-control" id="meno_psa" name="meno_psa" disabled="disabled">
                        <xsl:attribute name="value">
                            <xsl:value-of select="my:meno_psa"/>
                          </xsl:attribute> </input>
                </div>
        
        
                <div class="form-group">
                    <label for="plemeno">Plemeno:</label>
                    <input type="text" class="form-control" id="plemeno" name="plemeno" disabled="disabled">
                        <xsl:attribute name="value">
                            <xsl:value-of select="my:plemeno"/>
                          </xsl:attribute> </input>
                </div>
        
                <div class="form-group">
                    <label for="pohlavie">Pohlavie psa:</label>
                    <input class="form-control" id="pohlavie" name="pohlavie" disabled="disabled" >
                        <xsl:attribute name="value">
                            <xsl:value-of select="my:pohlavie"/>
                          </xsl:attribute>
                    </input>
                </div>
        
                <div class="form-group">
                    <label for="farba">Farba:</label>
                    <input type="text" class="form-control" id="farba" name="farba" disabled="disabled" >
                        <xsl:attribute name="value">
                            <xsl:value-of select="my:farba"/>
                          </xsl:attribute> </input>
                </div>
        
                <div class="form-group">
                    <label for="znamka">Evidenčné číslo psa ( číslo známky ):</label>
                    <input type="number" class="form-control" id="znamka" name="znamka" disabled="disabled"  >
                        <xsl:attribute name="value">
                            <xsl:value-of select="my:znamka"/>
                          </xsl:attribute> </input>
                </div>
        
                <div class="form-group">
                    <label for="c_cipu">Číslo mikročipu alebo tetovacie číslo psa:</label>
                    <input type="number" class="form-control" id="c_cipu" name="c_cipu" disabled="disabled">
                        <xsl:attribute name="value">
                            <xsl:value-of select="my:c_cipu"/>
                          </xsl:attribute> </input>
                </div>
        
                <div class="form-group">
                    <label for="pocet_psov">Počet psov v držbe:</label>
                    <input type="number" class="form-control" id="pocet_psov" name="pocet_psov" disabled="disabled">
                        <xsl:attribute name="value">
                            <xsl:value-of select="my:pocet_psov"/>
                          </xsl:attribute> </input>
                </div>
        
                <div class="form-group">
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" id="pohryznutie" name="pohryznutie" disabled="disabled"> 
                            <xsl:if test=" my:pohryznutie = 'checked'">
                            <xsl:attribute name="checked">checked</xsl:attribute>
                          </xsl:if> </input>
                        <label class="form-check-label" for="pohryznutie">
                            Skutočnosť, že pes pohrýzol alebo poranil človeka
                        </label>
                    </div>
                </div>
        
                <div class="form-group">
                    <label for="datum">Dátum</label>
                    <input type="date" class="form-control" id="datum" name="datum" disabled="disabled">
                        <xsl:attribute name="value">
                            <xsl:value-of select="my:datum"/>
                          </xsl:attribute> </input>
                </div>
        
        
            </form>
            <br/>
            
        
        
            <section>
                <p>
                    *ak sa umiestnenie nezhoduje s miestom trvalého pobytu vlastníka ( držiteľa ) psa
                </p>
            </section>
        </div>
    </main>
    </xsl:for-each>
        </body>

</html>
</xsl:template>
</xsl:stylesheet>