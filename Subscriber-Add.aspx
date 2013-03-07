<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Subscriber-Add.aspx.cs" Inherits="Subscriber_Add" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" Runat="Server">
<script type="text/javascript" src="js/CastleT.js"></script>
    <script type="text/javascript">
		            Cufon('h1');
    </script>
     <style type="text/css">
label {
	padding:0 10px 10px 0;
	text-align:right;
	display:inline-block;
	width:150px;
}

h4 {
	font-size:18px;
	margin-top:10px;
	color:#f6f5bf;
	text-transform:uppercase;
}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPImage" Runat="Server">
    <img src="Images/Brand-of-the-Year-Small.jpg" alt="Brand of the Year" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPBody" Runat="Server">
<div id="inner-body">
<div id="inner-body-left">
<h1><%= SiteMap.CurrentNode.Title %></h1>

<p>Please complete the form below and click subscribe.
        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Subscriber" ShowMessageBox="true" ShowSummary="false" />
        <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>
        
            <br />
          <div id="divSubscriber" runat="server">
            <label>
                Email:</label>
           
                <asp:TextBox ID="txtEmail" runat="server" CssClass="FormFields" Width="250px">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email Required" ValidationGroup="Subscriber" Display="None"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email is in incorrect format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="Subscriber" Display="None"></asp:RegularExpressionValidator><br />

            <label>
                Name:</label>

                <asp:TextBox ID="txtName" runat="server" CssClass="FormFields" Width="250px">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                    ErrorMessage="Name Required" ValidationGroup="Subscriber" Display="None"></asp:RequiredFieldValidator><br />
            


            <label>
                Address: (optional)
            </label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="FormFields" Width="250px" Height="50px" TextMode="MultiLine"></asp:TextBox><br />

           <label>
                City:
            </label>
            <asp:DropDownList ID="ddlCity" runat="server" class="DDLFields" Width="265px">
      <asp:ListItem Value="">Select City</asp:ListItem>
      <asp:ListItem Value="Abbaspur">Abbaspur</asp:ListItem>
      <asp:ListItem Value="Abbotabad">Abbotabad</asp:ListItem>
      <asp:ListItem Value="Abdul hakim">Abdul hakim</asp:ListItem>
      <asp:ListItem Value="Adda jahan khan">Adda jahan khan</asp:ListItem>
      <asp:ListItem Value="Adda shaiwala">Adda shaiwala</asp:ListItem>
      <asp:ListItem Value="Akhora khattak">Akhora khattak</asp:ListItem>
      <asp:ListItem Value="Ali chak">Ali chak</asp:ListItem>
      <asp:ListItem Value="Allahabad">Allahabad</asp:ListItem>
      <asp:ListItem Value="Amangarh">Amangarh</asp:ListItem>
      <asp:ListItem Value="Arif wala">Arif wala</asp:ListItem>
      <asp:ListItem Value="Arifwala">Arifwala</asp:ListItem>
      <asp:ListItem Value="Attock">Attock</asp:ListItem>
      <asp:ListItem Value="Babri banda">Babri banda</asp:ListItem>
      <asp:ListItem Value="Badin">Badin</asp:ListItem>
      <asp:ListItem Value="Bagh">Bagh</asp:ListItem>
      <asp:ListItem Value="Bahawalnagar">Bahawalnagar</asp:ListItem>
      <asp:ListItem Value="Bahawalpur">Bahawalpur</asp:ListItem>
      <asp:ListItem Value="Balakot">Balakot</asp:ListItem>
      <asp:ListItem Value="Bannu">Bannu</asp:ListItem>
      <asp:ListItem Value="Barbar loi">Barbar loi</asp:ListItem>
      <asp:ListItem Value="Baroute">Baroute</asp:ListItem>
      <asp:ListItem Value="Bat khela">Bat khela</asp:ListItem>
      <asp:ListItem Value="Battagram">Battagram</asp:ListItem>
      <asp:ListItem Value="Bewal">Bewal</asp:ListItem>
      <asp:ListItem Value="Bhai pheru">Bhai pheru</asp:ListItem>
      <asp:ListItem Value="Bhakkar">Bhakkar</asp:ListItem>
      <asp:ListItem Value="Bhalwal">Bhalwal</asp:ListItem>
      <asp:ListItem Value="Bhan saeedabad">Bhan saeedabad</asp:ListItem>
      <asp:ListItem Value="Bhara Kahu">Bhara Kahu</asp:ListItem>
      <asp:ListItem Value="Bhera">Bhera</asp:ListItem>
      <asp:ListItem Value="Bhimbar">Bhimbar</asp:ListItem>
      <asp:ListItem Value="Bhirya road">Bhirya road</asp:ListItem>
      <asp:ListItem Value="Bhuawana">Bhuawana</asp:ListItem>
      <asp:ListItem Value="Blitang">Blitang</asp:ListItem>
      <asp:ListItem Value="Buchay key">Buchay key</asp:ListItem>
      <asp:ListItem Value="Bunair">Bunair</asp:ListItem>
      <asp:ListItem Value="Bunner">Bunner</asp:ListItem>
      <asp:ListItem Value="Burewala">Burewala</asp:ListItem>
      <asp:ListItem Value="Chacklala">Chacklala</asp:ListItem>
      <asp:ListItem Value="Chaininda">Chaininda</asp:ListItem>
      <asp:ListItem Value="Chak 4 b c">Chak 4 b c</asp:ListItem>
      <asp:ListItem Value="Chak 46">Chak 46</asp:ListItem>
      <asp:ListItem Value="Chak jamal">Chak jamal</asp:ListItem>
      <asp:ListItem Value="Chak jhumra">Chak jhumra</asp:ListItem>
      <asp:ListItem Value="Chak sawara">Chak sawara</asp:ListItem>
      <asp:ListItem Value="Chak sheza">Chak sheza</asp:ListItem>
      <asp:ListItem Value="Chakwal">Chakwal</asp:ListItem>
      <asp:ListItem Value="Chaman">Chaman</asp:ListItem>
      <asp:ListItem Value="Charsada">Charsada</asp:ListItem>
      <asp:ListItem Value="Chashma">Chashma</asp:ListItem>
      <asp:ListItem Value="Chawinda">Chawinda</asp:ListItem>
      <asp:ListItem Value="Chicha watni">Chicha watni</asp:ListItem>
      <asp:ListItem Value="Chiniot">Chiniot</asp:ListItem>
      <asp:ListItem Value="Chishtian">Chishtian</asp:ListItem>
      <asp:ListItem Value="Chitral">Chitral</asp:ListItem>
      <asp:ListItem Value="Chohar jamali">Chohar jamali</asp:ListItem>
      <asp:ListItem Value="Choppar hatta">Choppar hatta</asp:ListItem>
      <asp:ListItem Value="Chowha saidan shah">Chowha saidan shah</asp:ListItem>
      <asp:ListItem Value="Chowk azam">Chowk azam</asp:ListItem>
      <asp:ListItem Value="Chowk mailta">Chowk mailta</asp:ListItem>
      <asp:ListItem Value="Chowk munda">Chowk munda</asp:ListItem>
      <asp:ListItem Value="Chunian">Chunian</asp:ListItem>
      <asp:ListItem Value="Dadakhel">Dadakhel</asp:ListItem>
      <asp:ListItem Value="Dadu">Dadu</asp:ListItem>
      <asp:ListItem Value="Daharki">Daharki</asp:ListItem>
      <asp:ListItem Value="Dandot">Dandot</asp:ListItem>
      <asp:ListItem Value="Dargai">Dargai</asp:ListItem>
      <asp:ListItem Value="Darya khan">Darya khan</asp:ListItem>
      <asp:ListItem Value="Daska">Daska</asp:ListItem>
      <asp:ListItem Value="Daud khel">Daud khel</asp:ListItem>
      <asp:ListItem Value="Daulat pur">Daulat pur</asp:ListItem>
      <asp:ListItem Value="Daur">Daur</asp:ListItem>
      <asp:ListItem Value="Deh pathaan">Deh pathaan</asp:ListItem>
      <asp:ListItem Value="Depal pur">Depal pur</asp:ListItem>
      <asp:ListItem Value="Dera ghazi khan">Dera ghazi khan</asp:ListItem>
      <asp:ListItem Value="Dera ismail khan">Dera ismail khan</asp:ListItem>
      <asp:ListItem Value="Dera murad jamali">Dera murad jamali</asp:ListItem>
      <asp:ListItem Value="Dera nawab sahib">Dera nawab sahib</asp:ListItem>
      <asp:ListItem Value="Dhatmal">Dhatmal</asp:ListItem>
      <asp:ListItem Value="Dhirkot">Dhirkot</asp:ListItem>
      <asp:ListItem Value="Dhoun kal">Dhoun kal</asp:ListItem>
      <asp:ListItem Value="Digri">Digri</asp:ListItem>
      <asp:ListItem Value="Dijkot">Dijkot</asp:ListItem>
      <asp:ListItem Value="Dina">Dina</asp:ListItem>
      <asp:ListItem Value="Dinga">Dinga</asp:ListItem>
      <asp:ListItem Value="Doaaba">Doaaba</asp:ListItem>
      <asp:ListItem Value="Doltala">Doltala</asp:ListItem>
      <asp:ListItem Value="Domeli">Domeli</asp:ListItem>
      <asp:ListItem Value="Dudial">Dudial</asp:ListItem>
      <asp:ListItem Value="Dunyapur">Dunyapur</asp:ListItem>
      <asp:ListItem Value="Eminabad">Eminabad</asp:ListItem>
      <asp:ListItem Value="Estate l.m factory">Estate l.m factory</asp:ListItem>
      <asp:ListItem Value="Faisalabad">Faisalabad</asp:ListItem>
      <asp:ListItem Value="Farooqabad">Farooqabad</asp:ListItem>
      <asp:ListItem Value="Fateh jang">Fateh jang</asp:ListItem>
      <asp:ListItem Value="Fateh pur">Fateh pur</asp:ListItem>
      <asp:ListItem Value="Feroz walla">Feroz walla</asp:ListItem>
      <asp:ListItem Value="Feroz watan">Feroz watan</asp:ListItem>
      <asp:ListItem Value="Fiza got">Fiza got</asp:ListItem>
      <asp:ListItem Value="Gadoon amazai">Gadoon amazai</asp:ListItem>
      <asp:ListItem Value="Gaggo mandi">Gaggo mandi</asp:ListItem>
      <asp:ListItem Value="Gakhar mandi">Gakhar mandi</asp:ListItem>
      <asp:ListItem Value="Gambet">Gambet</asp:ListItem>
      <asp:ListItem Value="Garh maharaja">Garh maharaja</asp:ListItem>
      <asp:ListItem Value="Garh more">Garh more</asp:ListItem>
      <asp:ListItem Value="Gari habibullah">Gari habibullah</asp:ListItem>
      <asp:ListItem Value="Gari mori">Gari mori</asp:ListItem>
      <asp:ListItem Value="Gawadar">Gawadar</asp:ListItem>
      <asp:ListItem Value="Gharo">Gharo</asp:ListItem>
      <asp:ListItem Value="Ghazi">Ghazi</asp:ListItem>
      <asp:ListItem Value="Ghotki">Ghotki</asp:ListItem>
      <asp:ListItem Value="Ghuzdar">Ghuzdar</asp:ListItem>
      <asp:ListItem Value="Gilgit">Gilgit</asp:ListItem>
      <asp:ListItem Value="Gohar ghoushti">Gohar ghoushti</asp:ListItem>
      <asp:ListItem Value="Gojar khan">Gojar khan</asp:ListItem>
      <asp:ListItem Value="Gojra">Gojra</asp:ListItem>
      <asp:ListItem Value="Goular khel">Goular khel</asp:ListItem>
      <asp:ListItem Value="Guddu">Guddu</asp:ListItem>
      <asp:ListItem Value="Gujjar khan">Gujjar khan</asp:ListItem>
      <asp:ListItem Value="Gujranwala">Gujranwala</asp:ListItem>
      <asp:ListItem Value="Gujrat">Gujrat</asp:ListItem>
      <asp:ListItem Value="Hafizabad">Hafizabad</asp:ListItem>
      <asp:ListItem Value="Hala">Hala</asp:ListItem>
      <asp:ListItem Value="Hangu">Hangu</asp:ListItem>
      <asp:ListItem Value="Hari pur">Hari pur</asp:ListItem>
      <asp:ListItem Value="Hariwala">Hariwala</asp:ListItem>
      <asp:ListItem Value="Haroonabad">Haroonabad</asp:ListItem>
      <asp:ListItem Value="Hasilpur">Hasilpur</asp:ListItem>
      <asp:ListItem Value="Hassan abdal">Hassan abdal</asp:ListItem>
      <asp:ListItem Value="Hattar">Hattar</asp:ListItem>
      <asp:ListItem Value="Hattian">Hattian</asp:ListItem>
      <asp:ListItem Value="Hattian lawrencepur">Hattian lawrencepur</asp:ListItem>
      <asp:ListItem Value="Haveli">Haveli</asp:ListItem>
      <asp:ListItem Value="Haveli lakha">Haveli lakha</asp:ListItem>
      <asp:ListItem Value="Havelian">Havelian</asp:ListItem>
      <asp:ListItem Value="Hayatabad">Hayatabad</asp:ListItem>
      <asp:ListItem Value="Hazro">Hazro</asp:ListItem>
      <asp:ListItem Value="Head marala">Head marala</asp:ListItem>
      <asp:ListItem Value="Hub Chowki">Hub Chowki</asp:ListItem>
      <asp:ListItem Value="Hub inds estate">Hub inds estate</asp:ListItem>
      <asp:ListItem Value="Hyderabad">Hyderabad</asp:ListItem>
      <asp:ListItem Value="Islamabad">Islamabad</asp:ListItem>
      <asp:ListItem Value="Issa khel">Issa khel</asp:ListItem>
      <asp:ListItem Value="Jaccobabad">Jaccobabad</asp:ListItem>
      <asp:ListItem Value="Jaja abasian">Jaja abasian</asp:ListItem>
      <asp:ListItem Value="Jalal pur jatan">Jalal pur jatan</asp:ListItem>
      <asp:ListItem Value="Jalal pur priwala">Jalal pur priwala</asp:ListItem>
      <asp:ListItem Value="Jampur">Jampur</asp:ListItem>
      <asp:ListItem Value="Jamrud road">Jamrud road</asp:ListItem>
      <asp:ListItem Value="Jamshoro">Jamshoro</asp:ListItem>
      <asp:ListItem Value="Jan pur">Jan pur</asp:ListItem>
      <asp:ListItem Value="Jandanwala">Jandanwala</asp:ListItem>
      <asp:ListItem Value="Jaranwala">Jaranwala</asp:ListItem>
      <asp:ListItem Value="Jauharabad">Jauharabad</asp:ListItem>
      <asp:ListItem Value="Jehangira">Jehangira</asp:ListItem>
      <asp:ListItem Value="Jehanian">Jehanian</asp:ListItem>
      <asp:ListItem Value="Jehlum">Jehlum</asp:ListItem>
      <asp:ListItem Value="Jhand">Jhand</asp:ListItem>
      <asp:ListItem Value="Jhang">Jhang</asp:ListItem>
      <asp:ListItem Value="Jhatta bhutta">Jhatta bhutta</asp:ListItem>
      <asp:ListItem Value="Jhelum">Jhelum</asp:ListItem>
      <asp:ListItem Value="Jhudo">Jhudo</asp:ListItem>
      <asp:ListItem Value="Joharabad">Joharabad</asp:ListItem>
      <asp:ListItem Value="Kabir wala">Kabir wala</asp:ListItem>
      <asp:ListItem Value="Kacha khooh">Kacha khooh</asp:ListItem>
      <asp:ListItem Value="Kahuta">Kahuta</asp:ListItem>
      <asp:ListItem Value="Kakul">Kakul</asp:ListItem>
      <asp:ListItem Value="Kakur town">Kakur town</asp:ListItem>
      <asp:ListItem Value="Kala bagh">Kala bagh</asp:ListItem>
      <asp:ListItem Value="Kala shah kaku">Kala shah kaku</asp:ListItem>
      <asp:ListItem Value="Kalar syedian">Kalar syedian</asp:ListItem>
      <asp:ListItem Value="Kalaswala">Kalaswala</asp:ListItem>
      <asp:ListItem Value="Kallur kot">Kallur kot</asp:ListItem>
      <asp:ListItem Value="Kamalia">Kamalia</asp:ListItem>
      <asp:ListItem Value="Kamalia musa">Kamalia musa</asp:ListItem>
      <asp:ListItem Value="Kamber ali khan">Kamber ali khan</asp:ListItem>
      <asp:ListItem Value="Kamokey">Kamokey</asp:ListItem>
      <asp:ListItem Value="Kamra">Kamra</asp:ListItem>
      <asp:ListItem Value="Kandh kot">Kandh kot</asp:ListItem>
      <asp:ListItem Value="Kandiaro">Kandiaro</asp:ListItem>
      <asp:ListItem Value="Karachi">Karachi</asp:ListItem>
      <asp:ListItem Value="Karak">Karak</asp:ListItem>
      <asp:ListItem Value="Karoor pacca">Karoor pacca</asp:ListItem>
      <asp:ListItem Value="Karore lalisan">Karore lalisan</asp:ListItem>
      <asp:ListItem Value="Kashmir">Kashmir</asp:ListItem>
      <asp:ListItem Value="Kashmore">Kashmore</asp:ListItem>
      <asp:ListItem Value="Kasur">Kasur</asp:ListItem>
      <asp:ListItem Value="Kazi ahmed">Kazi ahmed</asp:ListItem>
      <asp:ListItem Value="Khair pur">Khair pur</asp:ListItem>
      <asp:ListItem Value="Khair pur mir">Khair pur mir</asp:ListItem>
      <asp:ListItem Value="Khairpur nathan shah">Khairpur nathan shah</asp:ListItem>
      <asp:ListItem Value="Khan qah sharif">Khan qah sharif</asp:ListItem>
      <asp:ListItem Value="Khanbel">Khanbel</asp:ListItem>
      <asp:ListItem Value="Khandabad">Khandabad</asp:ListItem>
      <asp:ListItem Value="Khanewal">Khanewal</asp:ListItem>
      <asp:ListItem Value="Khangarh">Khangarh</asp:ListItem>
      <asp:ListItem Value="Khanpur">Khanpur</asp:ListItem>
      <asp:ListItem Value="Khanqah dogran">Khanqah dogran</asp:ListItem>
      <asp:ListItem Value="Khanqah sharif">Khanqah sharif</asp:ListItem>
      <asp:ListItem Value="Kharian">Kharian</asp:ListItem>
      <asp:ListItem Value="Khewra">Khewra</asp:ListItem>
      <asp:ListItem Value="Khoski">Khoski</asp:ListItem>
      <asp:ListItem Value="Khurian wala">Khurian wala</asp:ListItem>
      <asp:ListItem Value="Khushab">Khushab</asp:ListItem>
      <asp:ListItem Value="Khushal kot">Khushal kot</asp:ListItem>
      <asp:ListItem Value="Khuzdar">Khuzdar</asp:ListItem>
      <asp:ListItem Value="Kohat">Kohat</asp:ListItem>
      <asp:ListItem Value="Kot addu">Kot addu</asp:ListItem>
      <asp:ListItem Value="Kot bunglow">Kot bunglow</asp:ListItem>
      <asp:ListItem Value="Kot ghulam mohd">Kot ghulam mohd</asp:ListItem>
      <asp:ListItem Value="Kot mithan">Kot mithan</asp:ListItem>
      <asp:ListItem Value="Kot radha kishan">Kot radha kishan</asp:ListItem>
      <asp:ListItem Value="Kotla">Kotla</asp:ListItem>
      <asp:ListItem Value="Kotla arab ali khan">Kotla arab ali khan</asp:ListItem>
      <asp:ListItem Value="Kotla jam">Kotla jam</asp:ListItem>
      <asp:ListItem Value="Kotla patdan">Kotla patdan</asp:ListItem>
      <asp:ListItem Value="Kotli loharan">Kotli loharan</asp:ListItem>
      <asp:ListItem Value="Kotri">Kotri</asp:ListItem>
      <asp:ListItem Value="Kumbh">Kumbh</asp:ListItem>
      <asp:ListItem Value="Kundina">Kundina</asp:ListItem>
      <asp:ListItem Value="Kunjah">Kunjah</asp:ListItem>
      <asp:ListItem Value="Kunri">Kunri</asp:ListItem>
      <asp:ListItem Value="Lahore">Lahore</asp:ListItem>
      <asp:ListItem Value="Laki marwat">Laki marwat</asp:ListItem>
      <asp:ListItem Value="Lala musa">Lala musa</asp:ListItem>
      <asp:ListItem Value="Lala rukh">Lala rukh</asp:ListItem>
      <asp:ListItem Value="Laliah">Laliah</asp:ListItem>
      <asp:ListItem Value="Lalshanra">Lalshanra</asp:ListItem>
      <asp:ListItem Value="Larkana">Larkana</asp:ListItem>
      <asp:ListItem Value="Lawrence pur">Lawrence pur</asp:ListItem>
      <asp:ListItem Value="Layyah">Layyah</asp:ListItem>
      <asp:ListItem Value="Liaquat pur">Liaquat pur</asp:ListItem>
      <asp:ListItem Value="Lodhran">Lodhran</asp:ListItem>
      <asp:ListItem Value="Loralai">Loralai</asp:ListItem>
      <asp:ListItem Value="Lower Dir">Lower Dir</asp:ListItem>
      <asp:ListItem Value="Ludhan">Ludhan</asp:ListItem>
      <asp:ListItem Value="Machi goth">Machi goth</asp:ListItem>
      <asp:ListItem Value="Madina">Madina</asp:ListItem>
      <asp:ListItem Value="Mailsi">Mailsi</asp:ListItem>
      <asp:ListItem Value="Makli">Makli</asp:ListItem>
      <asp:ListItem Value="Malakwal">Malakwal</asp:ListItem>
      <asp:ListItem Value="Mamu kunjan">Mamu kunjan</asp:ListItem>
      <asp:ListItem Value="Mandi bahauddin">Mandi bahauddin</asp:ListItem>
      <asp:ListItem Value="Mandra">Mandra</asp:ListItem>
      <asp:ListItem Value="Manga mandi">Manga mandi</asp:ListItem>
      <asp:ListItem Value="Mangal sada">Mangal sada</asp:ListItem>
      <asp:ListItem Value="Mangi">Mangi</asp:ListItem>
      <asp:ListItem Value="Mangla">Mangla</asp:ListItem>
      <asp:ListItem Value="Mangowal">Mangowal</asp:ListItem>
      <asp:ListItem Value="Manoabad">Manoabad</asp:ListItem>
      <asp:ListItem Value="Manshera">Manshera</asp:ListItem>
      <asp:ListItem Value="Mardan">Mardan</asp:ListItem>
      <asp:ListItem Value="Mari indus">Mari indus</asp:ListItem>
      <asp:ListItem Value="Mastoi">Mastoi</asp:ListItem>
      <asp:ListItem Value="Matiari">Matiari</asp:ListItem>
      <asp:ListItem Value="Matli">Matli</asp:ListItem>
      <asp:ListItem Value="Mehar">Mehar</asp:ListItem>
      <asp:ListItem Value="Mehmood kot">Mehmood kot</asp:ListItem>
      <asp:ListItem Value="Mehrab pur">Mehrab pur</asp:ListItem>
      <asp:ListItem Value="Mian chunnu">Mian chunnu</asp:ListItem>
      <asp:ListItem Value="Mian Walli">Mian Walli</asp:ListItem>
      <asp:ListItem Value="Mingora">Mingora</asp:ListItem>
      <asp:ListItem Value="Mir ali">Mir ali</asp:ListItem>
      <asp:ListItem Value="Miran shah">Miran shah</asp:ListItem>
      <asp:ListItem Value="Mirpur">Mirpur</asp:ListItem>
      <asp:ListItem Value="Mirpur khas">Mirpur khas</asp:ListItem>
      <asp:ListItem Value="Mirpur mathelo">Mirpur mathelo</asp:ListItem>
      <asp:ListItem Value="Mohen jo daro">Mohen jo daro</asp:ListItem>
      <asp:ListItem Value="More kunda">More kunda</asp:ListItem>
      <asp:ListItem Value="Morgah">Morgah</asp:ListItem>
      <asp:ListItem Value="Moro">Moro</asp:ListItem>
      <asp:ListItem Value="Mubarik pur">Mubarik pur</asp:ListItem>
      <asp:ListItem Value="Multan">Multan</asp:ListItem>
      <asp:ListItem Value="Muridkay">Muridkay</asp:ListItem>
      <asp:ListItem Value="Murree">Murree</asp:ListItem>
      <asp:ListItem Value="Musafir khana">Musafir khana</asp:ListItem>
      <asp:ListItem Value="Mustung">Mustung</asp:ListItem>
      <asp:ListItem Value="Muzaffarabad">Muzaffarabad</asp:ListItem>
      <asp:ListItem Value="Muzaffargarh">Muzaffargarh</asp:ListItem>
      <asp:ListItem Value="Nankana sahib">Nankana sahib</asp:ListItem>
      <asp:ListItem Value="Narang mandi">Narang mandi</asp:ListItem>
      <asp:ListItem Value="Narowal">Narowal</asp:ListItem>
      <asp:ListItem Value="Naseerabad">Naseerabad</asp:ListItem>
      <asp:ListItem Value="Naudero">Naudero</asp:ListItem>
      <asp:ListItem Value="Naukot">Naukot</asp:ListItem>
      <asp:ListItem Value="Naukundi">Naukundi</asp:ListItem>
      <asp:ListItem Value="Nawab shah">Nawab shah</asp:ListItem>
      <asp:ListItem Value="New saeedabad">New saeedabad</asp:ListItem>
      <asp:ListItem Value="Nilore">Nilore</asp:ListItem>
      <asp:ListItem Value="Noor kot">Noor kot</asp:ListItem>
      <asp:ListItem Value="Noorpur nooranga">Noorpur nooranga</asp:ListItem>
      <asp:ListItem Value="Noshki">Noshki</asp:ListItem>
      <asp:ListItem Value="Nowshera">Nowshera</asp:ListItem>
      <asp:ListItem Value="Nowshera cantt">Nowshera cantt</asp:ListItem>
      <asp:ListItem Value="Nowshero peroz">Nowshero peroz</asp:ListItem>
      <asp:ListItem Value="Okara">Okara</asp:ListItem>
      <asp:ListItem Value="Padidan">Padidan</asp:ListItem>
      <asp:ListItem Value="Pak china fertilizer">Pak china fertilizer</asp:ListItem>
      <asp:ListItem Value="Pak pattan sharif">Pak pattan sharif</asp:ListItem>
      <asp:ListItem Value="Panjan kisan">Panjan kisan</asp:ListItem>
      <asp:ListItem Value="Panjgoor">Panjgoor</asp:ListItem>
      <asp:ListItem Value="Pannu aqil">Pannu aqil</asp:ListItem>
      <asp:ListItem Value="Pasni">Pasni</asp:ListItem>
      <asp:ListItem Value="Pasroor">Pasroor</asp:ListItem>
      <asp:ListItem Value="Patika">Patika</asp:ListItem>
      <asp:ListItem Value="Patoki">Patoki</asp:ListItem>
      <asp:ListItem Value="Peshawar">Peshawar</asp:ListItem>
      <asp:ListItem Value="Phagwar">Phagwar</asp:ListItem>
      <asp:ListItem Value="Phalia">Phalia</asp:ListItem>
      <asp:ListItem Value="Phool nagar">Phool nagar</asp:ListItem>
      <asp:ListItem Value="Piaro goth">Piaro goth</asp:ListItem>
      <asp:ListItem Value="Pindi Bhattian">Pindi Bhattian</asp:ListItem>
      <asp:ListItem Value="Pindi bhohri">Pindi bhohri</asp:ListItem>
      <asp:ListItem Value="Pindi dadan khan">Pindi dadan khan</asp:ListItem>
      <asp:ListItem Value="Pindi gheb">Pindi gheb</asp:ListItem>
      <asp:ListItem Value="Pir mahal">Pir mahal</asp:ListItem>
      <asp:ListItem Value="Pirpai">Pirpai</asp:ListItem>
      <asp:ListItem Value="Pishin">Pishin</asp:ListItem>
      <asp:ListItem Value="Punjgor">Punjgor</asp:ListItem>
      <asp:ListItem Value="Qalandarabad">Qalandarabad</asp:ListItem>
      <asp:ListItem Value="Qasba gujrat">Qasba gujrat</asp:ListItem>
      <asp:ListItem Value="Qazi ahmed">Qazi ahmed</asp:ListItem>
      <asp:ListItem Value="Quaidabad">Quaidabad</asp:ListItem>
      <asp:ListItem Value="Quetta">Quetta</asp:ListItem>
      <asp:ListItem Value="Rabwah">Rabwah</asp:ListItem>
      <asp:ListItem Value="Rahimyar khan">Rahimyar khan</asp:ListItem>
      <asp:ListItem Value="Rahwali">Rahwali</asp:ListItem>
      <asp:ListItem Value="Raiwand">Raiwand</asp:ListItem>
      <asp:ListItem Value="Rajana">Rajana</asp:ListItem>
      <asp:ListItem Value="Rajanpur">Rajanpur</asp:ListItem>
      <asp:ListItem Value="Rangoo">Rangoo</asp:ListItem>
      <asp:ListItem Value="Ranipur">Ranipur</asp:ListItem>
      <asp:ListItem Value="Ratto dero">Ratto dero</asp:ListItem>
      <asp:ListItem Value="Rawala kot">Rawala kot</asp:ListItem>
      <asp:ListItem Value="Rawalpindi">Rawalpindi</asp:ListItem>
      <asp:ListItem Value="Rawat">Rawat</asp:ListItem>
      <asp:ListItem Value="Renala khurd">Renala khurd</asp:ListItem>
      <asp:ListItem Value="Risalpur">Risalpur</asp:ListItem>
      <asp:ListItem Value="Rohri">Rohri</asp:ListItem>
      <asp:ListItem Value="Sadiqabad">Sadiqabad</asp:ListItem>
      <asp:ListItem Value="Sagri">Sagri</asp:ListItem>
      <asp:ListItem Value="Sahiwal">Sahiwal</asp:ListItem>
      <asp:ListItem Value="Saidu sharif">Saidu sharif</asp:ListItem>
      <asp:ListItem Value="Sajawal">Sajawal</asp:ListItem>
      <asp:ListItem Value="Sakrand">Sakrand</asp:ListItem>
      <asp:ListItem Value="Samanabad">Samanabad</asp:ListItem>
      <asp:ListItem Value="Sambrial">Sambrial</asp:ListItem>
      <asp:ListItem Value="Samma satta">Samma satta</asp:ListItem>
      <asp:ListItem Value="Samundri">Samundri</asp:ListItem>
      <asp:ListItem Value="Sanghar">Sanghar</asp:ListItem>
      <asp:ListItem Value="Sanghi">Sanghi</asp:ListItem>
      <asp:ListItem Value="Sangla hill">Sangla hill</asp:ListItem>
      <asp:ListItem Value="Sangote">Sangote</asp:ListItem>
      <asp:ListItem Value="Sanjwal">Sanjwal</asp:ListItem>
      <asp:ListItem Value="Sara e alamgir">Sara e alamgir</asp:ListItem>
      <asp:ListItem Value="Sara e naurang">Sara e naurang</asp:ListItem>
      <asp:ListItem Value="Sargodha">Sargodha</asp:ListItem>
      <asp:ListItem Value="Satyana bangla">Satyana bangla</asp:ListItem>
      <asp:ListItem Value="Sehar baqlas">Sehar baqlas</asp:ListItem>
      <asp:ListItem Value="Serai alamgir">Serai alamgir</asp:ListItem>
      <asp:ListItem Value="Shadiwal">Shadiwal</asp:ListItem>
      <asp:ListItem Value="Shah kot">Shah kot</asp:ListItem>
      <asp:ListItem Value="Shahdad kot">Shahdad kot</asp:ListItem>
      <asp:ListItem Value="Shahdad pur">Shahdad pur</asp:ListItem>
      <asp:ListItem Value="Shahpur chakar">Shahpur chakar</asp:ListItem>
      <asp:ListItem Value="Shaikhupura">Shaikhupura</asp:ListItem>
      <asp:ListItem Value="Shakargraph">Shakargraph</asp:ListItem>
      <asp:ListItem Value="Shamsabad">Shamsabad</asp:ListItem>
      <asp:ListItem Value="Shankiari">Shankiari</asp:ListItem>
      <asp:ListItem Value="Shedani sharif">Shedani sharif</asp:ListItem>
      <asp:ListItem Value="Sheikhupura">Sheikhupura</asp:ListItem>
      <asp:ListItem Value="Shemier">Shemier</asp:ListItem>
      <asp:ListItem Value="Shikar pur">Shikar pur</asp:ListItem>
      <asp:ListItem Value="Shorkot">Shorkot</asp:ListItem>
      <asp:ListItem Value="Shujabad">Shujabad</asp:ListItem>
      <asp:ListItem Value="Sialkot">Sialkot</asp:ListItem>
      <asp:ListItem Value="Sibi">Sibi</asp:ListItem>
      <asp:ListItem Value="Sihala">Sihala</asp:ListItem>
      <asp:ListItem Value="Sikandarabad">Sikandarabad</asp:ListItem>
      <asp:ListItem Value="Silanwala">Silanwala</asp:ListItem>
      <asp:ListItem Value="Sita road">Sita road</asp:ListItem>
      <asp:ListItem Value="Skardu">Skardu</asp:ListItem>
      <asp:ListItem Value="Sohawa district daska">Sohawa district daska</asp:ListItem>
      <asp:ListItem Value="Sohawa district jelum">Sohawa district jelum</asp:ListItem>
      <asp:ListItem Value="Sukkur">Sukkur</asp:ListItem>
      <asp:ListItem Value="Swabi">Swabi</asp:ListItem>
      <asp:ListItem Value="Swatmingora">Swatmingora</asp:ListItem>
      <asp:ListItem Value="Takhtbai">Takhtbai</asp:ListItem>
      <asp:ListItem Value="Talagang">Talagang</asp:ListItem>
      <asp:ListItem Value="Talamba">Talamba</asp:ListItem>
      <asp:ListItem Value="Talhur">Talhur</asp:ListItem>
      <asp:ListItem Value="Tando adam">Tando adam</asp:ListItem>
      <asp:ListItem Value="Tando allahyar">Tando allahyar</asp:ListItem>
      <asp:ListItem Value="Tando jam">Tando jam</asp:ListItem>
      <asp:ListItem Value="Tando mohd khan">Tando mohd khan</asp:ListItem>
      <asp:ListItem Value="Tank">Tank</asp:ListItem>
      <asp:ListItem Value="Tarbela">Tarbela</asp:ListItem>
      <asp:ListItem Value="Tarmatan">Tarmatan</asp:ListItem>
      <asp:ListItem Value="Tarnol">Tarnol</asp:ListItem>
      <asp:ListItem Value="Taunsa sharif">Taunsa sharif</asp:ListItem>
      <asp:ListItem Value="Taxila">Taxila</asp:ListItem>
      <asp:ListItem Value="Tharo shah">Tharo shah</asp:ListItem>
      <asp:ListItem Value="Tharparkar">Tharparkar</asp:ListItem>
      <asp:ListItem Value="Thatta">Thatta</asp:ListItem>
      <asp:ListItem Value="Theing jattan more">Theing jattan more</asp:ListItem>
      <asp:ListItem Value="Thull">Thull</asp:ListItem>
      <asp:ListItem Value="Tibba sultanpur">Tibba sultanpur</asp:ListItem>
      <asp:ListItem Value="Tobatek singh">Tobatek singh</asp:ListItem>
      <asp:ListItem Value="Topi">Topi</asp:ListItem>
      <asp:ListItem Value="Toru">Toru</asp:ListItem>
      <asp:ListItem Value="Trinda mohd pannah">Trinda mohd pannah</asp:ListItem>
      <asp:ListItem Value="Turbat">Turbat</asp:ListItem>
      <asp:ListItem Value="Ubaro">Ubaro</asp:ListItem>
      <asp:ListItem Value="Ugoki">Ugoki</asp:ListItem>
      <asp:ListItem Value="Ukba">Ukba</asp:ListItem>
      <asp:ListItem Value="Umar kot">Umar kot</asp:ListItem>
      <asp:ListItem Value="Upper deval">Upper deval</asp:ListItem>
      <asp:ListItem Value="Upper Dir">Upper Dir</asp:ListItem>
      <asp:ListItem Value="Usta mohammad">Usta mohammad</asp:ListItem>
      <asp:ListItem Value="Vehari">Vehari</asp:ListItem>
      <asp:ListItem Value="Village Sunder">Village Sunder</asp:ListItem>
      <asp:ListItem Value="Wah cantt">Wah cantt</asp:ListItem>
      <asp:ListItem Value="Wahi hassain">Wahi hassain</asp:ListItem>
      <asp:ListItem Value="Wan radha ram">Wan radha ram</asp:ListItem>
      <asp:ListItem Value="Warah">Warah</asp:ListItem>
      <asp:ListItem Value="Warburton">Warburton</asp:ListItem>
      <asp:ListItem Value="Wazirabad">Wazirabad</asp:ListItem>
      <asp:ListItem Value="Yazman mandi">Yazman mandi</asp:ListItem>
      <asp:ListItem Value="Zahir pir">Zahir pir</asp:ListItem>
      <asp:ListItem Value="Ziarat">Ziarat</asp:ListItem>
      </asp:DropDownList>
                <asp:TextBox ID="txtCity" runat="server" CssClass="FormFields" Width="250px" Visible="false">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCity"
                    ErrorMessage="City Required" ValidationGroup="Subscriber" Display="None"></asp:RequiredFieldValidator><br />

          <label>&nbsp;</label>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Subscribe" ValidationGroup="Subscriber" CssClass="FormButtons" />
      </div>  
 </div>
<div id="inner-body-right">

</div>
</div></asp:Content>

