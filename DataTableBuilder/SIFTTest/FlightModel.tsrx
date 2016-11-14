<?xml version="1.0" encoding="utf-8"?>
<applicationModel>
  <name>Application Model</name>
  <className>FlightModel</className>
  <objects>
    <object technology="WPF" type="Window">
      <name>HP MyFlight Sample Application</name>
      <codeName>HPMyFlightSampleApplicationWindow</codeName>
      <identification>
        <properties>
          <property name="ObjectName" type="string">HP MyFlight Sample Application</property>
          <property name="FullType" type="string">window</property>
          <property name="WindowTitleRegExp" type="string">HP MyFlight Sample Application</property>
        </properties>
      </identification>
      <children>
        <object technology="WPF" type="EditField">
          <name>agentName</name>
          <codeName>AgentNameEditField</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string">agentName</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="Image">
          <name>WpfImage</name>
          <codeName>WpfImage</codeName>
          <identification>
            <index>0</index>
          </identification>
        </object>
        <object technology="WPF" type="EditField">
          <name>password</name>
          <codeName>PasswordEditField</codeName>
          <identification>
            <properties>
              <property name="ObjectName" type="string">password</property>
            </properties>
          </identification>
        </object>
        <object technology="WPF" type="Image">
          <name>WpfImage1</name>
          <codeName>WpfImage1</codeName>
          <identification>
            <index>1</index>
          </identification>
        </object>
        <object technology="WPF" type="Button">
          <name>Cancel</name>
          <codeName>CancelButton</codeName>
          <identification />
        </object>
        <object technology="WPF" type="Button">
          <name>WpfButton</name>
          <codeName>WpfButton</codeName>
          <identification />
        </object>
        <object technology="WPF" type="TabStrip">
          <name>WpfTabStrip</name>
          <codeName>WpfTabStrip</codeName>
          <identification />
        </object>
        <object technology="WPF" type="ComboBox">
          <name>fromCity</name>
          <codeName>FromCityComboBox</codeName>
          <identification />
        </object>
        <object technology="WPF" type="ComboBox">
          <name>toCity</name>
          <codeName>ToCityComboBox</codeName>
          <identification />
        </object>
        <object technology="WPF" type="Calendar">
          <name>datePicker</name>
          <codeName>DatePickerCalendar</codeName>
          <identification />
        </object>
        <object technology="WPF" type="Image">
          <name>WpfImage2</name>
          <codeName>WpfImage2</codeName>
          <identification>
            <index>2</index>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>WpfObject</name>
          <codeName>WpfObjectUiObject</codeName>
          <identification />
        </object>
        <object technology="WPF" type="UiObject">
          <name>Class</name>
          <codeName>ClassUiObject</codeName>
          <identification />
        </object>
        <object technology="WPF" type="UiObject">
          <name>Tickets</name>
          <codeName>TicketsUiObject</codeName>
          <identification />
        </object>
        <object technology="WPF" type="ComboBox">
          <name>Class</name>
          <codeName>ClassComboBox</codeName>
          <identification />
        </object>
        <object technology="WPF" type="Image">
          <name>WpfImage3</name>
          <codeName>WpfImage3</codeName>
          <identification>
            <index>3</index>
          </identification>
        </object>
        <object technology="WPF" type="ComboBox">
          <name>numOfTickets</name>
          <codeName>NumOfTicketsComboBox</codeName>
          <identification />
        </object>
        <object technology="WPF" type="Image">
          <name>WpfImage4</name>
          <codeName>WpfImage4</codeName>
          <identification>
            <index>4</index>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>Seattle to San Francisco,
all inclusive</name>
          <codeName>SeattleToSanFranciscoAllInclusiveUiObject</codeName>
          <identification />
        </object>
        <object technology="WPF" type="UiObject">
          <name>from</name>
          <codeName>FromUiObject</codeName>
          <identification>
            <index>1</index>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>$</name>
          <codeName>UiObject</codeName>
          <identification>
            <index>1</index>
          </identification>
        </object>
        <object technology="WPF" type="UiObject">
          <name>99</name>
          <codeName>UiObject1</codeName>
          <identification />
        </object>
        <object technology="WPF" type="UiObject">
          <name>Hello</name>
          <codeName>HelloUiObject</codeName>
          <identification />
        </object>
        <object technology="WPF" type="UiObject">
          <name>John Smith</name>
          <codeName>JohnSmithUiObject</codeName>
          <identification />
        </object>
        <object technology="WPF" type="Table">
          <name>flightsDataGrid</name>
          <codeName>FlightsDataGridTable</codeName>
          <identification />
        </object>
        <object technology="WPF" type="UiObject">
          <name>WpfObject1</name>
          <codeName>WpfObjectUiObject1</codeName>
          <identification>
            <index>2</index>
          </identification>
        </object>
        <object technology="WPF" type="Button">
          <name>WpfButton1</name>
          <codeName>WpfButton1</codeName>
          <identification>
            <index>1</index>
          </identification>
        </object>
        <object technology="WPF" type="ProgressBar">
          <name>progBar</name>
          <codeName>ProgBarProgressBar</codeName>
          <identification />
        </object>
        <object technology="WPF" type="Button">
          <name>OK</name>
          <codeName>OKButton</codeName>
          <identification>
            <properties>
              <property name="Text" type="string">OK</property>
              <property name="ObjectName" type="string">okButton</property>
            </properties>
          </identification>
        </object>
        <object technology="Standard Windows" type="Dialog">
          <name>Login Failed</name>
          <codeName>LoginFailedDialog</codeName>
          <identification>
            <properties>
              <property name="IsChildWindow" type="boolean">false</property>
              <property name="Text" type="string">Login Failed</property>
            </properties>
          </identification>
        </object>
      </children>
    </object>
  </objects>
</applicationModel>