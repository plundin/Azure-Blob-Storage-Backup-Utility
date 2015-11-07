﻿/*
 * File: MimeTypes.cs
 * Author: Patrik Lundin, patrik@lundin.info
 * 
 * Maps and looks up the mime type for a file extension
 * 
 * Released under the Microsoft Public License (Ms-PL) http://www.microsoft.com/en-us/openness/licenses.aspx
*/
using System;
using System.Collections.Generic;

namespace AzureBlobBackup
{
    /// <summary>
    /// Implements a class for looking up mime types from file extensions.
    /// </summary>
    public class MimeTypes
    {
        // Holds mime type mappings
        private Dictionary<string, string> mimeTypes;
        // Holds reference to instance for singleton
        private static MimeTypes instance;

        /// <summary>
        /// Creates instance with common mappings
        /// </summary>
        public MimeTypes()
        {
            mimeTypes = new Dictionary<string, string>();

            #region Common mime type mappings
            mimeTypes.Add(".123","application/vnd.lotus-1-2-3");
            mimeTypes.Add(".3dml","text/vnd.in3d.3dml");
            mimeTypes.Add(".3g2","video/3gpp2");
            mimeTypes.Add(".3gp","video/3gpp");
            mimeTypes.Add(".7z","application/x-7z-compressed");
            mimeTypes.Add(".aab","application/x-authorware-bin");
            mimeTypes.Add(".aac","audio/x-aac");
            mimeTypes.Add(".aam","application/x-authorware-map");
            mimeTypes.Add(".aas","application/x-authorware-seg");
            mimeTypes.Add(".abw","application/x-abiword");
            mimeTypes.Add(".ac","application/pkix-attr-cert");
            mimeTypes.Add(".acc","application/vnd.americandynamics.acc");
            mimeTypes.Add(".ace","application/x-ace-compressed");
            mimeTypes.Add(".acu","application/vnd.acucobol");
            mimeTypes.Add(".adp","audio/adpcm");
            mimeTypes.Add(".aep","application/vnd.audiograph");
            mimeTypes.Add(".afp","application/vnd.ibm.modcap");
            mimeTypes.Add(".ahead","application/vnd.ahead.space");
            mimeTypes.Add(".ai","application/postscript");
            mimeTypes.Add(".aif","audio/x-aiff");
            mimeTypes.Add(".air","application/vnd.adobe.air-application-installer-package+zip");
            mimeTypes.Add(".ait","application/vnd.dvb.ait");
            mimeTypes.Add(".ami","application/vnd.amiga.ami");
            mimeTypes.Add(".apk","application/vnd.android.package-archive");
            mimeTypes.Add(".application","application/x-ms-application");
            mimeTypes.Add(".apr","application/vnd.lotus-approach");
            mimeTypes.Add(".asf","video/x-ms-asf");
            mimeTypes.Add(".aso","application/vnd.accpac.simply.aso");
            mimeTypes.Add(".atc","application/vnd.acucorp");
            mimeTypes.Add(".atom","application/atom+xml");
            mimeTypes.Add(".atomcat","application/atomcat+xml");
            mimeTypes.Add(".atomsvc","application/atomsvc+xml");
            mimeTypes.Add(".atx","application/vnd.antix.game-component");
            mimeTypes.Add(".au","audio/basic");
            mimeTypes.Add(".aw","application/applixware");
            mimeTypes.Add(".avi","video/x-msvideo");
            mimeTypes.Add(".azf","application/vnd.airzip.filesecure.azf");
            mimeTypes.Add(".azs","application/vnd.airzip.filesecure.azs");
            mimeTypes.Add(".azw","application/vnd.amazon.ebook");
            mimeTypes.Add(".bcpio","application/x-bcpio");
            mimeTypes.Add(".bdf","application/x-font-bdf");
            mimeTypes.Add(".bdm","application/vnd.syncml.dm+wbxml");
            mimeTypes.Add(".bed","application/vnd.realvnc.bed");
            mimeTypes.Add(".bh2","application/vnd.fujitsu.oasysprs");
            mimeTypes.Add(".bin","application/octet-stream");
            mimeTypes.Add(".bmi","application/vnd.bmi");
            mimeTypes.Add(".bmp","image/bmp");
            mimeTypes.Add(".box","application/vnd.previewsystems.box");
            mimeTypes.Add(".btif","image/prs.btif");
            mimeTypes.Add(".bz","application/x-bzip");
            mimeTypes.Add(".bz2","application/x-bzip2");
            mimeTypes.Add(".c","text/plain");
            mimeTypes.Add(".cs", "text/plain");
            mimeTypes.Add(".cpp", "text/plain");
            mimeTypes.Add(".c11amc","application/vnd.cluetrust.cartomobile-config");
            mimeTypes.Add(".c11amz","application/vnd.cluetrust.cartomobile-config-pkg");
            mimeTypes.Add(".c4g","application/vnd.clonk.c4group");
            mimeTypes.Add(".cab","application/vnd.ms-cab-compressed");
            mimeTypes.Add(".car","application/vnd.curl.car");
            mimeTypes.Add(".cat","application/vnd.ms-pki.seccat");
            mimeTypes.Add(".ccxml","application/ccxml+xml");
            mimeTypes.Add(".cdbcmsg","application/vnd.contact.cmsg");
            mimeTypes.Add(".cdkey","application/vnd.mediastation.cdkey");
            mimeTypes.Add(".cdmia","application/cdmi-capability");
            mimeTypes.Add(".cdmic","application/cdmi-container");
            mimeTypes.Add(".cdmid","application/cdmi-domain");
            mimeTypes.Add(".cdmio","application/cdmi-object");
            mimeTypes.Add(".cdmiq","application/cdmi-queue");
            mimeTypes.Add(".cdx","chemical/x-cdx");
            mimeTypes.Add(".cdxml","application/vnd.chemdraw+xml");
            mimeTypes.Add(".cdy","application/vnd.cinderella");
            mimeTypes.Add(".cer","application/pkix-cert");
            mimeTypes.Add(".cgm","image/cgm");
            mimeTypes.Add(".chat","application/x-chat");
            mimeTypes.Add(".chm","application/vnd.ms-htmlhelp");
            mimeTypes.Add(".chrt","application/vnd.kde.kchart");
            mimeTypes.Add(".cif","chemical/x-cif");
            mimeTypes.Add(".cii","application/vnd.anser-web-certificate-issue-initiation");
            mimeTypes.Add(".cil","application/vnd.ms-artgalry");
            mimeTypes.Add(".cla","application/vnd.claymore");
            mimeTypes.Add(".class","application/octet-stream");
            mimeTypes.Add(".clkk","application/vnd.crick.clicker.keyboard");
            mimeTypes.Add(".clkp","application/vnd.crick.clicker.palette");
            mimeTypes.Add(".clkt","application/vnd.crick.clicker.template");
            mimeTypes.Add(".clkw","application/vnd.crick.clicker.wordbank");
            mimeTypes.Add(".clkx","application/vnd.crick.clicker");
            mimeTypes.Add(".clp","application/x-msclip");
            mimeTypes.Add(".cmc","application/vnd.cosmocaller");
            mimeTypes.Add(".cmdf","chemical/x-cmdf");
            mimeTypes.Add(".cml","chemical/x-cml");
            mimeTypes.Add(".cmp","application/vnd.yellowriver-custom-menu");
            mimeTypes.Add(".cmx","image/x-cmx");
            mimeTypes.Add(".cod","application/vnd.rim.cod");
            mimeTypes.Add(".cpio","application/x-cpio");
            mimeTypes.Add(".cpt","application/mac-compactpro");
            mimeTypes.Add(".crd","application/x-mscardfile");
            mimeTypes.Add(".crl","application/pkix-crl");
            mimeTypes.Add(".cryptonote","application/vnd.rig.cryptonote");
            mimeTypes.Add(".csh","application/x-csh");
            mimeTypes.Add(".csml","chemical/x-csml");
            mimeTypes.Add(".csp","application/vnd.commonspace");
            mimeTypes.Add(".css","text/css");
            mimeTypes.Add(".csv","text/csv");
            mimeTypes.Add(".cu","application/cu-seeme");
            mimeTypes.Add(".curl","text/vnd.curl");
            mimeTypes.Add(".cww","application/prs.cww");
            mimeTypes.Add(".dae","model/vnd.collada+xml");
            mimeTypes.Add(".daf","application/vnd.mobius.daf");
            mimeTypes.Add(".davmount","application/davmount+xml");
            mimeTypes.Add(".dcurl","text/vnd.curl.dcurl");
            mimeTypes.Add(".dd2","application/vnd.oma.dd2+xml");
            mimeTypes.Add(".ddd","application/vnd.fujixerox.ddd");
            mimeTypes.Add(".deb","application/x-debian-package");
            mimeTypes.Add(".der","application/x-x509-ca-cert");
            mimeTypes.Add(".dfac","application/vnd.dreamfactory");
            mimeTypes.Add(".dir","application/x-director");
            mimeTypes.Add(".dis","application/vnd.mobius.dis");
            mimeTypes.Add(".djvu","image/vnd.djvu");
            mimeTypes.Add(".dna","application/vnd.dna");
            mimeTypes.Add(".doc","application/msword");
            mimeTypes.Add(".docm","application/vnd.ms-word.document.macroenabled.12");
            mimeTypes.Add(".docx","application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            mimeTypes.Add(".dotm","application/vnd.ms-word.template.macroenabled.12");
            mimeTypes.Add(".dotx","application/vnd.openxmlformats-officedocument.wordprocessingml.template");
            mimeTypes.Add(".dp","application/vnd.osgi.dp");
            mimeTypes.Add(".dpg","application/vnd.dpgraph");
            mimeTypes.Add(".dra","audio/vnd.dra");
            mimeTypes.Add(".dsc","text/prs.lines.tag");
            mimeTypes.Add(".dssc","application/dssc+der");
            mimeTypes.Add(".dtb","application/x-dtbook+xml");
            mimeTypes.Add(".dtd","application/xml-dtd");
            mimeTypes.Add(".dts","audio/vnd.dts");
            mimeTypes.Add(".dtshd","audio/vnd.dts.hd");
            mimeTypes.Add(".dwf","model/vnd.dwf");
            mimeTypes.Add(".dwg","image/vnd.dwg");
            mimeTypes.Add(".dvi","application/x-dvi");
            mimeTypes.Add(".dxf","image/vnd.dxf");
            mimeTypes.Add(".dxp","application/vnd.spotfire.dxp");
            mimeTypes.Add(".ecelp4800","audio/vnd.nuera.ecelp4800");
            mimeTypes.Add(".ecelp7470","audio/vnd.nuera.ecelp7470");
            mimeTypes.Add(".ecelp9600","audio/vnd.nuera.ecelp9600");
            mimeTypes.Add(".edm","application/vnd.novadigm.edm");
            mimeTypes.Add(".edx","application/vnd.novadigm.edx");
            mimeTypes.Add(".efif","application/vnd.picsel");
            mimeTypes.Add(".ei6","application/vnd.pg.osasli");
            mimeTypes.Add(".eml","message/rfc822");
            mimeTypes.Add(".emma","application/emma+xml");
            mimeTypes.Add(".eol","audio/vnd.digital-winds");
            mimeTypes.Add(".eot","application/vnd.ms-fontobject");
            mimeTypes.Add(".epub","application/epub+zip");
            mimeTypes.Add(".es","application/ecmascript");
            mimeTypes.Add(".es3","application/vnd.eszigno3+xml");
            mimeTypes.Add(".esf","application/vnd.epson.esf");
            mimeTypes.Add(".etx","text/x-setext");
            mimeTypes.Add(".exe","application/x-msdownload");
            mimeTypes.Add(".exi","application/exi");
            mimeTypes.Add(".ext","application/vnd.novadigm.ext");
            mimeTypes.Add(".ez2","application/vnd.ezpix-album");
            mimeTypes.Add(".ez3","application/vnd.ezpix-package");
            mimeTypes.Add(".f","text/x-fortran");
            mimeTypes.Add(".f4v","video/x-f4v");
            mimeTypes.Add(".fbs","image/vnd.fastbidsheet");
            mimeTypes.Add(".fcs","application/vnd.isac.fcs");
            mimeTypes.Add(".fdf","application/vnd.fdf");
            mimeTypes.Add(".fe_launch","application/vnd.denovo.fcselayout-link");
            mimeTypes.Add(".fg5","application/vnd.fujitsu.oasysgp");
            mimeTypes.Add(".fh","image/x-freehand");
            mimeTypes.Add(".fig","application/x-xfig");
            mimeTypes.Add(".fli","video/x-fli");
            mimeTypes.Add(".flo","application/vnd.micrografx.flo");
            mimeTypes.Add(".flv","video/x-flv");
            mimeTypes.Add(".flw","application/vnd.kde.kivio");
            mimeTypes.Add(".flx","text/vnd.fmi.flexstor");
            mimeTypes.Add(".fly","text/vnd.fly");
            mimeTypes.Add(".fm","application/vnd.framemaker");
            mimeTypes.Add(".fnc","application/vnd.frogans.fnc");
            mimeTypes.Add(".fpx","image/vnd.fpx");
            mimeTypes.Add(".fsc","application/vnd.fsc.weblaunch");
            mimeTypes.Add(".fst","image/vnd.fst");
            mimeTypes.Add(".ftc","application/vnd.fluxtime.clip");
            mimeTypes.Add(".fti","application/vnd.anser-web-funds-transfer-initiation");
            mimeTypes.Add(".fvt","video/vnd.fvt");
            mimeTypes.Add(".fxp","application/vnd.adobe.fxp");
            mimeTypes.Add(".fzs","application/vnd.fuzzysheet");
            mimeTypes.Add(".g2w","application/vnd.geoplan");
            mimeTypes.Add(".g3","image/g3fax");
            mimeTypes.Add(".g3w","application/vnd.geospace");
            mimeTypes.Add(".gac","application/vnd.groove-account");
            mimeTypes.Add(".gdl","model/vnd.gdl");
            mimeTypes.Add(".geo","application/vnd.dynageo");
            mimeTypes.Add(".gex","application/vnd.geometry-explorer");
            mimeTypes.Add(".ggb","application/vnd.geogebra.file");
            mimeTypes.Add(".ggt","application/vnd.geogebra.tool");
            mimeTypes.Add(".ghf","application/vnd.groove-help");
            mimeTypes.Add(".gif","image/gif");
            mimeTypes.Add(".gim","application/vnd.groove-identity-message");
            mimeTypes.Add(".gmx","application/vnd.gmx");
            mimeTypes.Add(".gnumeric","application/x-gnumeric");
            mimeTypes.Add(".gph","application/vnd.flographit");
            mimeTypes.Add(".gqf","application/vnd.grafeq");
            mimeTypes.Add(".gram","application/srgs");
            mimeTypes.Add(".grv","application/vnd.groove-injector");
            mimeTypes.Add(".grxml","application/srgs+xml");
            mimeTypes.Add(".gsf","application/x-font-ghostscript");
            mimeTypes.Add(".gtar","application/x-gtar");
            mimeTypes.Add(".gtm","application/vnd.groove-tool-message");
            mimeTypes.Add(".gtw","model/vnd.gtw");
            mimeTypes.Add(".gv","text/vnd.graphviz");
            mimeTypes.Add(".gxt","application/vnd.geonext");
            mimeTypes.Add(".h", "text/plain");
            mimeTypes.Add(".h261","video/h261");
            mimeTypes.Add(".h263","video/h263");
            mimeTypes.Add(".h264","video/h264");
            mimeTypes.Add(".hal","application/vnd.hal+xml");
            mimeTypes.Add(".hbci","application/vnd.hbci");
            mimeTypes.Add(".hdf","application/x-hdf");
            mimeTypes.Add(".hlp","application/winhlp");
            mimeTypes.Add(".hpgl","application/vnd.hp-hpgl");
            mimeTypes.Add(".hpid","application/vnd.hp-hpid");
            mimeTypes.Add(".hps","application/vnd.hp-hps");
            mimeTypes.Add(".hqx","application/mac-binhex40");
            mimeTypes.Add(".htke","application/vnd.kenameaapp");
            mimeTypes.Add(".html","text/html");
            mimeTypes.Add(".hvd","application/vnd.yamaha.hv-dic");
            mimeTypes.Add(".hvp","application/vnd.yamaha.hv-voice");
            mimeTypes.Add(".hvs","application/vnd.yamaha.hv-script");
            mimeTypes.Add(".i2g","application/vnd.intergeo");
            mimeTypes.Add(".icc","application/vnd.iccprofile");
            mimeTypes.Add(".ice","x-conference/x-cooltalk");
            mimeTypes.Add(".ico","image/x-icon");
            mimeTypes.Add(".ics","text/calendar");
            mimeTypes.Add(".ief","image/ief");
            mimeTypes.Add(".ifm","application/vnd.shana.informed.formdata");
            mimeTypes.Add(".igl","application/vnd.igloader");
            mimeTypes.Add(".igm","application/vnd.insors.igm");
            mimeTypes.Add(".igs","model/iges");
            mimeTypes.Add(".igx","application/vnd.micrografx.igx");
            mimeTypes.Add(".iif","application/vnd.shana.informed.interchange");
            mimeTypes.Add(".imp","application/vnd.accpac.simply.imp");
            mimeTypes.Add(".ims","application/vnd.ms-ims");
            mimeTypes.Add(".ipfix","application/ipfix");
            mimeTypes.Add(".ipk","application/vnd.shana.informed.package");
            mimeTypes.Add(".irm","application/vnd.ibm.rights-management");
            mimeTypes.Add(".irp","application/vnd.irepository.package+xml");
            mimeTypes.Add(".itp","application/vnd.shana.informed.formtemplate");
            mimeTypes.Add(".ivp","application/vnd.immervision-ivp");
            mimeTypes.Add(".ivu","application/vnd.immervision-ivu");
            mimeTypes.Add(".jad","text/vnd.sun.j2me.app-descriptor");
            mimeTypes.Add(".jam","application/vnd.jam");
            mimeTypes.Add(".jar","application/java-archive");
            mimeTypes.Add(".java","text/plain");
            mimeTypes.Add(".jisp","application/vnd.jisp");
            mimeTypes.Add(".jlt","application/vnd.hp-jlyt");
            mimeTypes.Add(".jnlp","application/x-java-jnlp-file");
            mimeTypes.Add(".joda","application/vnd.joost.joda-archive");
            mimeTypes.Add(".jpeg","image/jpeg");
            mimeTypes.Add(".jpg","image/jpeg");
            mimeTypes.Add(".jpgv","video/jpeg");
            mimeTypes.Add(".jpm","video/jpm");
            mimeTypes.Add(".js","application/javascript");
            mimeTypes.Add(".json","application/json");
            mimeTypes.Add(".karbon","application/vnd.kde.karbon");
            mimeTypes.Add(".kfo","application/vnd.kde.kformula");
            mimeTypes.Add(".kia","application/vnd.kidspiration");
            mimeTypes.Add(".kml","application/vnd.google-earth.kml+xml");
            mimeTypes.Add(".kmz","application/vnd.google-earth.kmz");
            mimeTypes.Add(".kne","application/vnd.kinar");
            mimeTypes.Add(".kon","application/vnd.kde.kontour");
            mimeTypes.Add(".kpr","application/vnd.kde.kpresenter");
            mimeTypes.Add(".ksp","application/vnd.kde.kspread");
            mimeTypes.Add(".ktx","image/ktx");
            mimeTypes.Add(".ktz","application/vnd.kahootz");
            mimeTypes.Add(".kwd","application/vnd.kde.kword");
            mimeTypes.Add(".lasxml","application/vnd.las.las+xml");
            mimeTypes.Add(".latex","application/x-latex");
            mimeTypes.Add(".lbd","application/vnd.llamagraphics.life-balance.desktop");
            mimeTypes.Add(".lbe","application/vnd.llamagraphics.life-balance.exchange+xml");
            mimeTypes.Add(".les","application/vnd.hhe.lesson-player");
            mimeTypes.Add(".link66","application/vnd.route66.link66+xml");
            mimeTypes.Add(".lrm","application/vnd.ms-lrm");
            mimeTypes.Add(".ltf","application/vnd.frogans.ltf");
            mimeTypes.Add(".lvp","audio/vnd.lucent.voice");
            mimeTypes.Add(".lwp","application/vnd.lotus-wordpro");
            mimeTypes.Add(".m21","application/mp21");
            mimeTypes.Add(".m3u","audio/x-mpegurl");
            mimeTypes.Add(".m3u8","application/vnd.apple.mpegurl");
            mimeTypes.Add(".m4v","video/x-m4v");
            mimeTypes.Add(".ma","application/mathematica");
            mimeTypes.Add(".mads","application/mads+xml");
            mimeTypes.Add(".mag","application/vnd.ecowin.chart");
            mimeTypes.Add(".mathml","application/mathml+xml");
            mimeTypes.Add(".mbk","application/vnd.mobius.mbk");
            mimeTypes.Add(".mbox","application/mbox");
            mimeTypes.Add(".mc1","application/vnd.medcalcdata");
            mimeTypes.Add(".mcd","application/vnd.mcd");
            mimeTypes.Add(".mcurl","text/vnd.curl.mcurl");
            mimeTypes.Add(".mdb","application/x-msaccess");
            mimeTypes.Add(".mdi","image/vnd.ms-modi");
            mimeTypes.Add(".meta4","application/metalink4+xml");
            mimeTypes.Add(".mets","application/mets+xml");
            mimeTypes.Add(".mfm","application/vnd.mfmp");
            mimeTypes.Add(".mgp","application/vnd.osgeo.mapguide.package");
            mimeTypes.Add(".mgz","application/vnd.proteus.magazine");
            mimeTypes.Add(".mid","audio/midi");
            mimeTypes.Add(".mif","application/vnd.mif");
            mimeTypes.Add(".mj2","video/mj2");
            mimeTypes.Add(".mlp","application/vnd.dolby.mlp");
            mimeTypes.Add(".mmd","application/vnd.chipnuts.karaoke-mmd");
            mimeTypes.Add(".mmf","application/vnd.smaf");
            mimeTypes.Add(".mmr","image/vnd.fujixerox.edmics-mmr");
            mimeTypes.Add(".mny","application/x-msmoney");
            mimeTypes.Add(".mods","application/mods+xml");
            mimeTypes.Add(".movie","video/x-sgi-movie");
            mimeTypes.Add(".mp4","video/mp4");
            mimeTypes.Add(".mp4a","audio/mp4");
            mimeTypes.Add(".mpc","application/vnd.mophun.certificate");
            mimeTypes.Add(".mpeg","video/mpeg");
            mimeTypes.Add(".mpga","audio/mpeg");
            mimeTypes.Add(".mpkg","application/vnd.apple.installer+xml");
            mimeTypes.Add(".mpm","application/vnd.blueice.multipass");
            mimeTypes.Add(".mpn","application/vnd.mophun.application");
            mimeTypes.Add(".mpp","application/vnd.ms-project");
            mimeTypes.Add(".mpy","application/vnd.ibm.minipay");
            mimeTypes.Add(".mqy","application/vnd.mobius.mqy");
            mimeTypes.Add(".mrc","application/marc");
            mimeTypes.Add(".mrcx","application/marcxml+xml");
            mimeTypes.Add(".mscml","application/mediaservercontrol+xml");
            mimeTypes.Add(".mseq","application/vnd.mseq");
            mimeTypes.Add(".msf","application/vnd.epson.msf");
            mimeTypes.Add(".msh","model/mesh");
            mimeTypes.Add(".msl","application/vnd.mobius.msl");
            mimeTypes.Add(".msty","application/vnd.muvee.style");
            mimeTypes.Add(".mts","model/vnd.mts");
            mimeTypes.Add(".mus","application/vnd.musician");
            mimeTypes.Add(".musicxml","application/vnd.recordare.musicxml+xml");
            mimeTypes.Add(".mvb","application/x-msmediaview");
            mimeTypes.Add(".mwf","application/vnd.mfer");
            mimeTypes.Add(".mxf","application/mxf");
            mimeTypes.Add(".mxl","application/vnd.recordare.musicxml");
            mimeTypes.Add(".mxml","application/xv+xml");
            mimeTypes.Add(".mxs","application/vnd.triscape.mxs");
            mimeTypes.Add(".mxu","video/vnd.mpegurl");
            mimeTypes.Add(".n3","text/n3");
            mimeTypes.Add(".nbp","application/vnd.wolfram.player");
            mimeTypes.Add(".nc","application/x-netcdf");
            mimeTypes.Add(".ncx","application/x-dtbncx+xml");
            mimeTypes.Add(".n-gage","application/vnd.nokia.n-gage.symbian.install");
            mimeTypes.Add(".ngdat","application/vnd.nokia.n-gage.data");
            mimeTypes.Add(".nlu","application/vnd.neurolanguage.nlu");
            mimeTypes.Add(".nml","application/vnd.enliven");
            mimeTypes.Add(".nnd","application/vnd.noblenet-directory");
            mimeTypes.Add(".nns","application/vnd.noblenet-sealer");
            mimeTypes.Add(".nnw","application/vnd.noblenet-web");
            mimeTypes.Add(".npx","image/vnd.net-fpx");
            mimeTypes.Add(".nsf","application/vnd.lotus-notes");
            mimeTypes.Add(".oa2","application/vnd.fujitsu.oasys2");
            mimeTypes.Add(".oa3","application/vnd.fujitsu.oasys3");
            mimeTypes.Add(".oas","application/vnd.fujitsu.oasys");
            mimeTypes.Add(".obd","application/x-msbinder");
            mimeTypes.Add(".oda","application/oda");
            mimeTypes.Add(".odb","application/vnd.oasis.opendocument.database");
            mimeTypes.Add(".odc","application/vnd.oasis.opendocument.chart");
            mimeTypes.Add(".odf","application/vnd.oasis.opendocument.formula");
            mimeTypes.Add(".odft","application/vnd.oasis.opendocument.formula-template");
            mimeTypes.Add(".odg","application/vnd.oasis.opendocument.graphics");
            mimeTypes.Add(".odi","application/vnd.oasis.opendocument.image");
            mimeTypes.Add(".odm","application/vnd.oasis.opendocument.text-master");
            mimeTypes.Add(".odp","application/vnd.oasis.opendocument.presentation");
            mimeTypes.Add(".ods","application/vnd.oasis.opendocument.spreadsheet");
            mimeTypes.Add(".odt","application/vnd.oasis.opendocument.text");
            mimeTypes.Add(".oga","audio/ogg");
            mimeTypes.Add(".ogv","video/ogg");
            mimeTypes.Add(".ogx","application/ogg");
            mimeTypes.Add(".onetoc","application/onenote");
            mimeTypes.Add(".opf","application/oebps-package+xml");
            mimeTypes.Add(".org","application/vnd.lotus-organizer");
            mimeTypes.Add(".osf","application/vnd.yamaha.openscoreformat");
            mimeTypes.Add(".osfpvg","application/vnd.yamaha.openscoreformat.osfpvg+xml");
            mimeTypes.Add(".otc","application/vnd.oasis.opendocument.chart-template");
            mimeTypes.Add(".otf","application/x-font-otf");
            mimeTypes.Add(".otg","application/vnd.oasis.opendocument.graphics-template");
            mimeTypes.Add(".oth","application/vnd.oasis.opendocument.text-web");
            mimeTypes.Add(".oti","application/vnd.oasis.opendocument.image-template");
            mimeTypes.Add(".otp","application/vnd.oasis.opendocument.presentation-template");
            mimeTypes.Add(".ots","application/vnd.oasis.opendocument.spreadsheet-template");
            mimeTypes.Add(".ott","application/vnd.oasis.opendocument.text-template");
            mimeTypes.Add(".oxt","application/vnd.openofficeorg.extension");
            mimeTypes.Add(".p","text/x-pascal");
            mimeTypes.Add(".p10","application/pkcs10");
            mimeTypes.Add(".p12","application/x-pkcs12");
            mimeTypes.Add(".p7b","application/x-pkcs7-certificates");
            mimeTypes.Add(".p7m","application/pkcs7-mime");
            mimeTypes.Add(".p7r","application/x-pkcs7-certreqresp");
            mimeTypes.Add(".p7s","application/pkcs7-signature");
            mimeTypes.Add(".p8","application/pkcs8");
            mimeTypes.Add(".paw","application/vnd.pawaafile");
            mimeTypes.Add(".pbd","application/vnd.powerbuilder6");
            mimeTypes.Add(".pbm","image/x-portable-bitmap");
            mimeTypes.Add(".pcf","application/x-font-pcf");
            mimeTypes.Add(".pcl","application/vnd.hp-pcl");
            mimeTypes.Add(".pclxl","application/vnd.hp-pclxl");
            mimeTypes.Add(".pcurl","application/vnd.curl.pcurl");
            mimeTypes.Add(".pcx","image/x-pcx");
            mimeTypes.Add(".pdb","application/vnd.palm");
            mimeTypes.Add(".pdf","application/pdf");
            mimeTypes.Add(".pfa","application/x-font-type1");
            mimeTypes.Add(".pfr","application/font-tdpfr");
            mimeTypes.Add(".pgm","image/x-portable-graymap");
            mimeTypes.Add(".pgn","application/x-chess-pgn");
            mimeTypes.Add(".pgp","application/pgp-signature");
            mimeTypes.Add(".pic","image/x-pict");
            mimeTypes.Add(".pki","application/pkixcmp");
            mimeTypes.Add(".pkipath","application/pkix-pkipath");
            mimeTypes.Add(".plb","application/vnd.3gpp.pic-bw-large");
            mimeTypes.Add(".plc","application/vnd.mobius.plc");
            mimeTypes.Add(".plf","application/vnd.pocketlearn");
            mimeTypes.Add(".pls","application/pls+xml");
            mimeTypes.Add(".pml","application/vnd.ctc-posml");
            mimeTypes.Add(".png","image/png");
            mimeTypes.Add(".pnm","image/x-portable-anymap");
            mimeTypes.Add(".portpkg","application/vnd.macports.portpkg");
            mimeTypes.Add(".potm","application/vnd.ms-powerpoint.template.macroenabled.12");
            mimeTypes.Add(".potx","application/vnd.openxmlformats-officedocument.presentationml.template");
            mimeTypes.Add(".ppam","application/vnd.ms-powerpoint.addin.macroenabled.12");
            mimeTypes.Add(".ppd","application/vnd.cups-ppd");
            mimeTypes.Add(".ppm","image/x-portable-pixmap");
            mimeTypes.Add(".ppsm","application/vnd.ms-powerpoint.slideshow.macroenabled.12");
            mimeTypes.Add(".ppsx","application/vnd.openxmlformats-officedocument.presentationml.slideshow");
            mimeTypes.Add(".ppt","application/vnd.ms-powerpoint");
            mimeTypes.Add(".pptm","application/vnd.ms-powerpoint.presentation.macroenabled.12");
            mimeTypes.Add(".pptx","application/vnd.openxmlformats-officedocument.presentationml.presentation");
            mimeTypes.Add(".prc","application/x-mobipocket-ebook");
            mimeTypes.Add(".pre","application/vnd.lotus-freelance");
            mimeTypes.Add(".prf","application/pics-rules");
            mimeTypes.Add(".psb","application/vnd.3gpp.pic-bw-small");
            mimeTypes.Add(".psd","image/vnd.adobe.photoshop");
            mimeTypes.Add(".psf","application/x-font-linux-psf");
            mimeTypes.Add(".pskcxml","application/pskc+xml");
            mimeTypes.Add(".ptid","application/vnd.pvi.ptid1");
            mimeTypes.Add(".pub","application/x-mspublisher");
            mimeTypes.Add(".pvb","application/vnd.3gpp.pic-bw-var");
            mimeTypes.Add(".pwn","application/vnd.3m.post-it-notes");
            mimeTypes.Add(".pya","audio/vnd.ms-playready.media.pya");
            mimeTypes.Add(".pyv","video/vnd.ms-playready.media.pyv");
            mimeTypes.Add(".qam","application/vnd.epson.quickanime");
            mimeTypes.Add(".qbo","application/vnd.intu.qbo");
            mimeTypes.Add(".qfx","application/vnd.intu.qfx");
            mimeTypes.Add(".qps","application/vnd.publishare-delta-tree");
            mimeTypes.Add(".qt","video/quicktime");
            mimeTypes.Add(".qxd","application/vnd.quark.quarkxpress");
            mimeTypes.Add(".ram","audio/x-pn-realaudio");
            mimeTypes.Add(".rar","application/x-rar-compressed");
            mimeTypes.Add(".ras","image/x-cmu-raster");
            mimeTypes.Add(".rcprofile","application/vnd.ipunplugged.rcprofile");
            mimeTypes.Add(".rdf","application/rdf+xml");
            mimeTypes.Add(".rdz","application/vnd.data-vision.rdz");
            mimeTypes.Add(".rep","application/vnd.businessobjects");
            mimeTypes.Add(".res","application/x-dtbresource+xml");
            mimeTypes.Add(".rgb","image/x-rgb");
            mimeTypes.Add(".rif","application/reginfo+xml");
            mimeTypes.Add(".rip","audio/vnd.rip");
            mimeTypes.Add(".rl","application/resource-lists+xml");
            mimeTypes.Add(".rlc","image/vnd.fujixerox.edmics-rlc");
            mimeTypes.Add(".rld","application/resource-lists-diff+xml");
            mimeTypes.Add(".rm","application/vnd.rn-realmedia");
            mimeTypes.Add(".rmp","audio/x-pn-realaudio-plugin");
            mimeTypes.Add(".rms","application/vnd.jcp.javame.midlet-rms");
            mimeTypes.Add(".rnc","application/relax-ng-compact-syntax");
            mimeTypes.Add(".rp9","application/vnd.cloanto.rp9");
            mimeTypes.Add(".rpss","application/vnd.nokia.radio-presets");
            mimeTypes.Add(".rpst","application/vnd.nokia.radio-preset");
            mimeTypes.Add(".rq","application/sparql-query");
            mimeTypes.Add(".rs","application/rls-services+xml");
            mimeTypes.Add(".rsd","application/rsd+xml");
            mimeTypes.Add(".rss","application/rss+xml");
            mimeTypes.Add(".rtf","application/rtf");
            mimeTypes.Add(".rtx","text/richtext");
            mimeTypes.Add(".s","text/x-asm");
            mimeTypes.Add(".saf","application/vnd.yamaha.smaf-audio");
            mimeTypes.Add(".sbml","application/sbml+xml");
            mimeTypes.Add(".sc","application/vnd.ibm.secure-container");
            mimeTypes.Add(".scd","application/x-msschedule");
            mimeTypes.Add(".scm","application/vnd.lotus-screencam");
            mimeTypes.Add(".scq","application/scvp-cv-request");
            mimeTypes.Add(".scs","application/scvp-cv-response");
            mimeTypes.Add(".scurl","text/vnd.curl.scurl");
            mimeTypes.Add(".sda","application/vnd.stardivision.draw");
            mimeTypes.Add(".sdc","application/vnd.stardivision.calc");
            mimeTypes.Add(".sdd","application/vnd.stardivision.impress");
            mimeTypes.Add(".sdkm","application/vnd.solent.sdkm+xml");
            mimeTypes.Add(".sdp","application/sdp");
            mimeTypes.Add(".sdw","application/vnd.stardivision.writer");
            mimeTypes.Add(".see","application/vnd.seemail");
            mimeTypes.Add(".seed","application/vnd.fdsn.seed");
            mimeTypes.Add(".sema","application/vnd.sema");
            mimeTypes.Add(".semd","application/vnd.semd");
            mimeTypes.Add(".semf","application/vnd.semf");
            mimeTypes.Add(".ser","application/java-serialized-object");
            mimeTypes.Add(".setpay","application/set-payment-initiation");
            mimeTypes.Add(".setreg","application/set-registration-initiation");
            mimeTypes.Add(".sfd-hdstx","application/vnd.hydrostatix.sof-data");
            mimeTypes.Add(".sfs","application/vnd.spotfire.sfs");
            mimeTypes.Add(".sgl","application/vnd.stardivision.writer-global");
            mimeTypes.Add(".sgml","text/sgml");
            mimeTypes.Add(".sh","application/x-sh");
            mimeTypes.Add(".shar","application/x-shar");
            mimeTypes.Add(".shf","application/shf+xml");
            mimeTypes.Add(".sis","application/vnd.symbian.install");
            mimeTypes.Add(".sit","application/x-stuffit");
            mimeTypes.Add(".sitx","application/x-stuffitx");
            mimeTypes.Add(".skp","application/vnd.koan");
            mimeTypes.Add(".sldm","application/vnd.ms-powerpoint.slide.macroenabled.12");
            mimeTypes.Add(".sldx","application/vnd.openxmlformats-officedocument.presentationml.slide");
            mimeTypes.Add(".slt","application/vnd.epson.salt");
            mimeTypes.Add(".sm","application/vnd.stepmania.stepchart");
            mimeTypes.Add(".smf","application/vnd.stardivision.math");
            mimeTypes.Add(".smi","application/smil+xml");
            mimeTypes.Add(".snf","application/x-font-snf");
            mimeTypes.Add(".spf","application/vnd.yamaha.smaf-phrase");
            mimeTypes.Add(".spl","application/x-futuresplash");
            mimeTypes.Add(".spot","text/vnd.in3d.spot");
            mimeTypes.Add(".spp","application/scvp-vp-response");
            mimeTypes.Add(".spq","application/scvp-vp-request");
            mimeTypes.Add(".src","application/x-wais-source");
            mimeTypes.Add(".sru","application/sru+xml");
            mimeTypes.Add(".srx","application/sparql-results+xml");
            mimeTypes.Add(".sse","application/vnd.kodak-descriptor");
            mimeTypes.Add(".ssf","application/vnd.epson.ssf");
            mimeTypes.Add(".ssml","application/ssml+xml");
            mimeTypes.Add(".st","application/vnd.sailingtracker.track");
            mimeTypes.Add(".stc","application/vnd.sun.xml.calc.template");
            mimeTypes.Add(".std","application/vnd.sun.xml.draw.template");
            mimeTypes.Add(".stf","application/vnd.wt.stf");
            mimeTypes.Add(".sti","application/vnd.sun.xml.impress.template");
            mimeTypes.Add(".stk","application/hyperstudio");
            mimeTypes.Add(".stl","application/vnd.ms-pki.stl");
            mimeTypes.Add(".str","application/vnd.pg.format");
            mimeTypes.Add(".stw","application/vnd.sun.xml.writer.template");
            mimeTypes.Add(".sub","image/vnd.dvb.subtitle");
            mimeTypes.Add(".sus","application/vnd.sus-calendar");
            mimeTypes.Add(".sv4cpio","application/x-sv4cpio");
            mimeTypes.Add(".sv4crc","application/x-sv4crc");
            mimeTypes.Add(".svc","application/vnd.dvb.service");
            mimeTypes.Add(".svd","application/vnd.svd");
            mimeTypes.Add(".swf","application/x-shockwave-flash");
            mimeTypes.Add(".svg","image/svg+xml");
            mimeTypes.Add(".swi","application/vnd.aristanetworks.swi");
            mimeTypes.Add(".sxc","application/vnd.sun.xml.calc");
            mimeTypes.Add(".sxd","application/vnd.sun.xml.draw");
            mimeTypes.Add(".sxg","application/vnd.sun.xml.writer.global");
            mimeTypes.Add(".sxi","application/vnd.sun.xml.impress");
            mimeTypes.Add(".sxm","application/vnd.sun.xml.math");
            mimeTypes.Add(".sxw","application/vnd.sun.xml.writer");
            mimeTypes.Add(".t","text/troff");
            mimeTypes.Add(".tao","application/vnd.tao.intent-module-archive");
            mimeTypes.Add(".tar","application/x-tar");
            mimeTypes.Add(".tcap","application/vnd.3gpp2.tcap");
            mimeTypes.Add(".tcl","application/x-tcl");
            mimeTypes.Add(".teacher","application/vnd.smart.teacher");
            mimeTypes.Add(".tei","application/tei+xml");
            mimeTypes.Add(".tex","application/x-tex");
            mimeTypes.Add(".texinfo","application/x-texinfo");
            mimeTypes.Add(".tfi","application/thraud+xml");
            mimeTypes.Add(".tfm","application/x-tex-tfm");
            mimeTypes.Add(".thmx","application/vnd.ms-officetheme");
            mimeTypes.Add(".tiff","image/tiff");
            mimeTypes.Add(".tmo","application/vnd.tmobile-livetv");
            mimeTypes.Add(".torrent","application/x-bittorrent");
            mimeTypes.Add(".tpl","application/vnd.groove-tool-template");
            mimeTypes.Add(".tpt","application/vnd.trid.tpt");
            mimeTypes.Add(".tra","application/vnd.trueapp");
            mimeTypes.Add(".trm","application/x-msterminal");
            mimeTypes.Add(".tsd","application/timestamped-data");
            mimeTypes.Add(".tsv","text/tab-separated-values");
            mimeTypes.Add(".ttf","application/x-font-ttf");
            mimeTypes.Add(".ttl","text/turtle");
            mimeTypes.Add(".twd","application/vnd.simtech-mindmapper");
            mimeTypes.Add(".txd","application/vnd.genomatix.tuxedo");
            mimeTypes.Add(".txf","application/vnd.mobius.txf");
            mimeTypes.Add(".txt","text/plain");
            mimeTypes.Add(".ufd","application/vnd.ufdl");
            mimeTypes.Add(".umj","application/vnd.umajin");
            mimeTypes.Add(".unityweb","application/vnd.unity");
            mimeTypes.Add(".uoml","application/vnd.uoml+xml");
            mimeTypes.Add(".uri","text/uri-list");
            mimeTypes.Add(".ustar","application/x-ustar");
            mimeTypes.Add(".utz","application/vnd.uiq.theme");
            mimeTypes.Add(".uu","text/x-uuencode");
            mimeTypes.Add(".uva","audio/vnd.dece.audio");
            mimeTypes.Add(".uvh","video/vnd.dece.hd");
            mimeTypes.Add(".uvi","image/vnd.dece.graphic");
            mimeTypes.Add(".uvm","video/vnd.dece.mobile");
            mimeTypes.Add(".uvp","video/vnd.dece.pd");
            mimeTypes.Add(".uvs","video/vnd.dece.sd");
            mimeTypes.Add(".uvu","video/vnd.uvvu.mp4");
            mimeTypes.Add(".uvv","video/vnd.dece.video");
            mimeTypes.Add(".wad","application/x-doom");
            mimeTypes.Add(".wav","audio/x-wav");
            mimeTypes.Add(".wax","audio/x-ms-wax");
            mimeTypes.Add(".wbmp","image/vnd.wap.wbmp");
            mimeTypes.Add(".wbs","application/vnd.criticaltools.wbs+xml");
            mimeTypes.Add(".wbxml","application/vnd.wap.wbxml");
            mimeTypes.Add(".vcd","application/x-cdlink");
            mimeTypes.Add(".vcf","text/x-vcard");
            mimeTypes.Add(".vcg","application/vnd.groove-vcard");
            mimeTypes.Add(".vcs","text/x-vcalendar");
            mimeTypes.Add(".vcx","application/vnd.vcx");
            mimeTypes.Add(".weba","audio/webm");
            mimeTypes.Add(".webm","video/webm");
            mimeTypes.Add(".webp","image/webp");
            mimeTypes.Add(".wg","application/vnd.pmi.widget");
            mimeTypes.Add(".wgt","application/widget");
            mimeTypes.Add(".vis","application/vnd.visionary");
            mimeTypes.Add(".viv","video/vnd.vivo");
            mimeTypes.Add(".wm","video/x-ms-wm");
            mimeTypes.Add(".wma","audio/x-ms-wma");
            mimeTypes.Add(".wmd","application/x-ms-wmd");
            mimeTypes.Add(".wmf","application/x-msmetafile");
            mimeTypes.Add(".wml","text/vnd.wap.wml");
            mimeTypes.Add(".wmlc","application/vnd.wap.wmlc");
            mimeTypes.Add(".wmls","text/vnd.wap.wmlscript");
            mimeTypes.Add(".wmlsc","application/vnd.wap.wmlscriptc");
            mimeTypes.Add(".wmv","video/x-ms-wmv");
            mimeTypes.Add(".wmx","video/x-ms-wmx");
            mimeTypes.Add(".wmz","application/x-ms-wmz");
            mimeTypes.Add(".woff","application/x-font-woff");
            mimeTypes.Add(".wpd","application/vnd.wordperfect");
            mimeTypes.Add(".wpl","application/vnd.ms-wpl");
            mimeTypes.Add(".wps","application/vnd.ms-works");
            mimeTypes.Add(".wqd","application/vnd.wqd");
            mimeTypes.Add(".wri","application/x-mswrite");
            mimeTypes.Add(".wrl","model/vrml");
            mimeTypes.Add(".vsd","application/vnd.visio");
            mimeTypes.Add(".wsdl","application/wsdl+xml");
            mimeTypes.Add(".vsf","application/vnd.vsf");
            mimeTypes.Add(".wspolicy","application/wspolicy+xml");
            mimeTypes.Add(".wtb","application/vnd.webturbo");
            mimeTypes.Add(".vtu","model/vnd.vtu");
            mimeTypes.Add(".wvx","video/x-ms-wvx");
            mimeTypes.Add(".vxml","application/voicexml+xml");
            mimeTypes.Add(".x3d","application/vnd.hzn-3d-crossword");
            mimeTypes.Add(".xap","application/x-silverlight-app");
            mimeTypes.Add(".xar","application/vnd.xara");
            mimeTypes.Add(".xbap","application/x-ms-xbap");
            mimeTypes.Add(".xbd","application/vnd.fujixerox.docuworks.binder");
            mimeTypes.Add(".xbm","image/x-xbitmap");
            mimeTypes.Add(".xdf","application/xcap-diff+xml");
            mimeTypes.Add(".xdm","application/vnd.syncml.dm+xml");
            mimeTypes.Add(".xdp","application/vnd.adobe.xdp+xml");
            mimeTypes.Add(".xdssc","application/dssc+xml");
            mimeTypes.Add(".xdw","application/vnd.fujixerox.docuworks");
            mimeTypes.Add(".xenc","application/xenc+xml");
            mimeTypes.Add(".xer","application/patch-ops-error+xml");
            mimeTypes.Add(".xfdf","application/vnd.adobe.xfdf");
            mimeTypes.Add(".xfdl","application/vnd.xfdl");
            mimeTypes.Add(".xhtml","application/xhtml+xml");
            mimeTypes.Add(".xif","image/vnd.xiff");
            mimeTypes.Add(".xlam","application/vnd.ms-excel.addin.macroenabled.12");
            mimeTypes.Add(".xls","application/vnd.ms-excel");
            mimeTypes.Add(".xlsb","application/vnd.ms-excel.sheet.binary.macroenabled.12");
            mimeTypes.Add(".xlsm","application/vnd.ms-excel.sheet.macroenabled.12");
            mimeTypes.Add(".xlsx","application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            mimeTypes.Add(".xltm","application/vnd.ms-excel.template.macroenabled.12");
            mimeTypes.Add(".xltx","application/vnd.openxmlformats-officedocument.spreadsheetml.template");
            mimeTypes.Add(".xml","application/xml");
            mimeTypes.Add(".xo","application/vnd.olpc-sugar");
            mimeTypes.Add(".xop","application/xop+xml");
            mimeTypes.Add(".xpi","application/x-xpinstall");
            mimeTypes.Add(".xpm","image/x-xpixmap");
            mimeTypes.Add(".xpr","application/vnd.is-xpr");
            mimeTypes.Add(".xps","application/vnd.ms-xpsdocument");
            mimeTypes.Add(".xpw","application/vnd.intercon.formnet");
            mimeTypes.Add(".xslt","application/xslt+xml");
            mimeTypes.Add(".xsm","application/vnd.syncml+xml");
            mimeTypes.Add(".xspf","application/xspf+xml");
            mimeTypes.Add(".xul","application/vnd.mozilla.xul+xml");
            mimeTypes.Add(".xwd","image/x-xwindowdump");
            mimeTypes.Add(".xyz","chemical/x-xyz");
            mimeTypes.Add(".yang","application/yang");
            mimeTypes.Add(".yin","application/yin+xml");
            mimeTypes.Add(".zaz","application/vnd.zzazz.deck+xml");
            mimeTypes.Add(".zip","application/zip");
            mimeTypes.Add(".zir","application/vnd.zul");
            mimeTypes.Add(".zmm","application/vnd.handheld-entertainment+xml");
            #endregion
        }


        /// <summary>
        /// Singleton
        /// </summary>
        public static MimeTypes Mapping
        {
            get
            {
                if (instance == null) instance = new MimeTypes();
                return instance;
            }
        }

        /// <summary>
        /// Retrieves a mime mapping from the file extension
        /// </summary>
        /// <param name="extension">File extension to get mime type for</param>
        /// <returns>The mapped mime type or application/octet-stream if not found</returns>
        public string this[string extension]
        {
            get
            {

                return getMapping(extension);
            }
        }

        /// <summary>
        /// Adds a mime mapping
        /// </summary>
        /// <param name="extension">File extension to use (for example .jpg)</param>
        /// <param name="mime">Mime string to use (for example image/jpeg)</param>
        /// <remarks>Most common types are already mapped</remarks>
        /// <returns>True if added, false otherwise</returns>
        public bool addMapping(string extension, string mime)
        {
            if(String.IsNullOrEmpty(extension) || String.IsNullOrEmpty(mime)) return false;
            
            if (extension[0] != '.') extension = "." + extension;
            extension = extension.ToLower();

            if (!mimeTypes.ContainsKey(extension))
            {
                mimeTypes.Add(extension, mime);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes a mime mapping
        /// </summary>
        /// <param name="extension">File extension to remove mapping for</param>
        /// <returns>True if removed, false otherwise</returns>
        public bool removeMapping(string extension)
        {
            if (String.IsNullOrEmpty(extension)) return false;
            
            if (extension[0] != '.') extension = "." + extension;
            extension = extension.ToLower();

            return mimeTypes.Remove(extension);
        }

        /// <summary>
        /// Retrieves a mime mapping from the file extension
        /// </summary>
        /// <param name="extension">File extension to get mime type for</param>
        /// <returns>The mapped mime type or application/octet-stream if not found</returns>
        public string getMapping(string extension)
        {
            if (String.IsNullOrEmpty(extension)) return "application/octet-stream";
            
            if (extension[0] != '.') extension = "." + extension;
            extension = extension.ToLower();

            if (mimeTypes.ContainsKey(extension)) return mimeTypes[extension];
            else return "application/octet-stream";
        }
    }
}
