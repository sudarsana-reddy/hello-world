<?xml version="1.0" encoding="utf-8"?>
<applicationModel>
  <name>Application Model</name>
  <className>ApplicationModel1</className>
  <objects>
    <object technology="WinForms" type="Window">
      <name>Form1 : Your choice</name>
      <codeName>Form1YourChoiceWindow</codeName>
      <identification>
        <properties>
          <property name="IsChildWindow" type="boolean">false</property>
          <property name="IsOwnedWindow" type="boolean">false</property>
          <property name="ObjectName" type="string">Form1</property>
          <property name="WindowTitleRegExp" type="string">Form1 : Your choice</property>
        </properties>
      </identification>
      <children>
        <object technology="WinForms" type="Window">
          <name>Form2 : English language</name>
          <codeName>Form2EnglishLanguageWindow</codeName>
          <identification>
            <properties>
              <property name="IsChildWindow" type="boolean">false</property>
              <property name="IsOwnedWindow" type="boolean">true</property>
              <property name="ObjectName" type="string">Form2</property>
              <property name="WindowTitleRegExp" type="string">Form2 : English language</property>
            </properties>
          </identification>
          <children>
            <object technology="Standard Windows" type="UiObject">
              <name>MSFlexGridWndClass</name>
              <codeName>MSFlexGridWndClassUiObject</codeName>
              <identification>
                <properties>
                  <property name="WindowClassRegExp" type="string">MSFlexGridWndClass</property>
                </properties>
              </identification>
            </object>
            <object technology="WinForms" type="UiObject">
              <name>mkGrid1</name>
              <codeName>MkGrid1UiObject</codeName>
              <identification />
            </object>
            <object technology="WinForms" type="UiObject">
              <name>picAbout</name>
              <codeName>PicAboutUiObject</codeName>
              <identification />
            </object>
          </children>
        </object>
      </children>
    </object>
  </objects>
</applicationModel>