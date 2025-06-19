<%@ Page Title="" Language="C#" MasterPageFile="~/Admin1.Master" AutoEventWireup="true" CodeBehind="ServisAM.aspx.cs" Inherits="Web___Projekat.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%">
        <div style="width:50%; float:left; text-align:center; ">
            <div style="background-color:#f7d291;">
                UNOS NOVE USLUGE :<br />
                <br />
                <asp:ListBox ID="ListaUsluga" runat="server" DataSourceID="SqlDataSource1" DataTextField="Usluga" DataValueField="usluga_id" OnSelectedIndexChanged="ListaUsluga_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AutoMehanicar %>" SelectCommand="SELECT usluga_id, naziv + ' ' + '$' + CAST(cena AS varchar) AS Usluga FROM [Usluga]"></asp:SqlDataSource>
                <br />
                <asp:Label ID="Label1" runat="server" Text="Naziv:"></asp:Label> <br />
                <asp:TextBox ID="txt_naziv" runat="server" ></asp:TextBox> 
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Cena:"></asp:Label> <br />
                <asp:TextBox ID="txt_cena" runat="server" style="margin-bottom: 0px"></asp:TextBox> 
                <br />
                <br /> <br />
                <div style="text-align: center;">
                    <table style="display: inline-block;">
                        <tr>
                            <td>
                                Pocetak:
                                <asp:Calendar ID="datum_p" runat="server" />
                            </td>
                            <td style="padding-left: 20px;">
                                Zavrsetak:
                                <asp:Calendar ID="datum_z" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div> 
                <br />
                <br />
                <asp:Button ID="btn_insert_usluga" runat="server" Text="Dodaj uslugu" OnClick="btn_insert_usluga_Click" />
                <asp:Button ID="btn_delete_uslugu" runat="server" Text="Obrisi uslugu" OnClick="btn_delete_uslugu_Click"/>
                <asp:Button ID="btn_update_usluga" runat="server" Text="Izmeni uslugu" OnClick="btn_update_usluga_Click" />
                <br />
                <br />
            </div>
            <div style="background-color:#247339;">

                UNOS VLASNIKA:

                <br />
                <br />
                <asp:ListBox ID="ListaVlasnika" runat="server" DataSourceID="SqlDataSource4" DataTextField="ImePrezime" DataValueField="email" OnSelectedIndexChanged="ListaVlasnika_SelectedIndexChanged"  AutoPostBack="true"></asp:ListBox> <br />
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:AutoMehanicar %>" SelectCommand="SELECT email, ime + ' ' + prezime AS ImePrezime FROM Vlasnik "></asp:SqlDataSource>
                <br />
                <asp:Label ID="Label8" runat="server" Text="Ime:"></asp:Label> <br />
                <asp:TextBox ID="txt_vlasnik_ime" runat="server" ></asp:TextBox> <br /> <br />
                <asp:Label ID="Label9" runat="server" Text="Prezime:"></asp:Label> <br />
                <asp:TextBox ID="txt_vlasnik_prezime" runat="server" ></asp:TextBox> <br /> <br />
                <asp:Label ID="Label10" runat="server" Text="Email:"></asp:Label> <br />
                <asp:TextBox ID="txt_vlasnik_email" runat="server" ></asp:TextBox> <br /> <br />
                <asp:Label ID="Label11" runat="server" Text="Lozinka:"></asp:Label> <br />
                <asp:TextBox ID="txt_vlasnik_lozinka" runat="server" ></asp:TextBox> <br /> <br />
                <asp:Label ID="Label12" runat="server" Text="JMBG:"></asp:Label> <br />
                <asp:TextBox ID="txt_vlasnik_jmbg" runat="server" ></asp:TextBox> 
                <br />
                <br />
                <asp:Button ID="btn_insert_vlasnik" runat="server" OnClick="btn_insert_vlasnik_Click" Text="Dodaj vlasnika" />
                <asp:Button ID="btn_delete_vlasnika" runat="server" OnClick="btn_delete_vlasnika_Click" Text="Obrisi vlasnika" />
                <asp:Button ID="btn_update_vlasnika" runat="server" Text="Izmeni vlasnika" OnClick="btn_update_vlasnika_Click" />
                <br /> <br />
            </div>
        </div>
        <div style="width:50%; float:left; text-align:center; height: 924px;">
            <div style=" background-color:#a37b0d; height:540px">
                UNOS NOVOG ZAPOSLENOG :<br />
                <br />
                <asp:ListBox ID="ListaZaposlenih" runat="server" DataSourceID="SqlDataSource2" DataTextField="Ime_Prezime" DataValueField="zaposleni_id" AutoPostBack="true" OnSelectedIndexChanged="ListaZaposlenih_SelectedIndexChanged"></asp:ListBox>
                <br />
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:AutoMehanicar %>" SelectCommand="SELECT zaposleni_id, ime + ' ' + prezime AS Ime_Prezime FROM Zaposleni"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:AutoMehanicar %>" SelectCommand="SELECT usluga_id, naziv + ' ' + '$' + CAST(cena AS varchar) AS Usluga FROM [Usluga]"></asp:SqlDataSource>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Ime:"></asp:Label> <br />
                <asp:TextBox ID="txt_ime" runat="server" ></asp:TextBox> <br /> <br />
                <asp:Label ID="Label4" runat="server" Text="Prezime:"></asp:Label> <br />
                <asp:TextBox ID="txt_prezime" runat="server" ></asp:TextBox> <br /> <br />
                <asp:Label ID="Label5" runat="server" Text="JMBG:"></asp:Label> <br />
                <asp:TextBox ID="txt_jmbg" runat="server" ></asp:TextBox> <br /> <br />
                <asp:Label ID="Label6" runat="server" Text="Plata:"></asp:Label> <br />
                <asp:TextBox ID="txt_plata" runat="server" ></asp:TextBox> <br /> <br />
                <asp:Label ID="Label7" runat="server" Text="Usluga:"></asp:Label> <br />
                <asp:DropDownList ID="dd_usluga_zaposleni" runat="server" DataSourceID="SqlDataSource3" DataTextField="Usluga" DataValueField="usluga_id" Height="30px" Width="123px"></asp:DropDownList>
                <br />
                <br />
                <br />
                <asp:Button ID="btn_insert_zaposleni" runat="server" Text="Dodaj zaposlenog" OnClick="btn_insert_zaposleni_Click" style="margin-top: 0px" />
                <asp:Button ID="btn_delete_zaposleni" runat="server" OnClick="btn_delete_zaposleni_Click" Text="Obrisi zaposlenog" />
                <asp:Button ID="btn_update_zaposleni" runat="server" Text="Izmeni zaposlenog" OnClick="btn_update_zaposleni_Click" />
                <br />
                <br />
                <br />
                <br />
            </div>
            <div style="background-color: #00FF99; height: 449px;">

                UNOS AUTOMOBILA:
                <br />
                <br />
                <asp:ListBox ID="ListaAuta" runat="server" DataSourceID="SqlDataSource5" DataTextField="Auto" DataValueField="auto_id" AutoPostBack="true" OnSelectedIndexChanged="ListaAuta_SelectedIndexChanged"></asp:ListBox>
                <br />
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:AutoMehanicar %>" SelectCommand="SELECT auto_id, marka + ' ' + registracija as Auto FROM Auto"></asp:SqlDataSource>
                <br />
                <asp:Label ID="Label13" runat="server" Text="Marka:"></asp:Label> <br />
                <asp:TextBox ID="txt_marka" runat="server" ></asp:TextBox> <br /> <br />
                <asp:Label ID="Label14" runat="server" Text="Registracija:"></asp:Label> <br />
                <asp:TextBox ID="txt_registracija" runat="server" ></asp:TextBox> <br /> <br />
                <asp:Label ID="Label15" runat="server" Text="Usluga:"></asp:Label> <br />
                <asp:DropDownList ID="ListaUsluga1" runat="server" DataSourceID="SqlDataSource3" DataTextField="Usluga" DataValueField="usluga_id" Height="30px" Width="123px"></asp:DropDownList>
                <br />
                <br />
                <br />
                <asp:Button ID="btn_insert_auto" runat="server" OnClick="btn_insert_auto_Click" Text="Dodaj automobil" />
                <asp:Button ID="btn_delete_automobil" runat="server" OnClick="btn_delete_automobil_Click" Text="Obrisi automobil" />
                <asp:Button ID="btn_update_automobil" runat="server" Text="Izmeni automobil" OnClick="btn_update_automobil_Click" />
                <br />
                <br />
            </div>
        </div>


    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


    </div>



</asp:Content>
