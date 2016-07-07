/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/
(function()
{
    function isVideoEmbed(element) {
        var attributes = element.attributes;
        return ((attributes.type == 'application/x-mplayer2') && true);

    }

    function createFakeElement(editor, realElement) {
        return editor.createFakeParserElement(realElement, 'cke_videoplayer', 'videoplayer', true);
    }

    CKEDITOR.plugins.add('videoplayer', {
	lang:'zh-cn',
    requires: 'dialog,fakeobjects',
    icons: 'videoplayer', 
    onLoad: function () {
        CKEDITOR.addCss('img.cke_videoplayer' +
            '{' +
                'background-image: url(' + CKEDITOR.getUrl(this.path + 'images/placeholder.png') + ');' +
                'background-position: center center;' +
                'background-repeat: no-repeat;' +
                'border: 1px solid #a9a9a9;' +
                'width: 80px;' +
                'height: 80px;' +
            '}'
            );
    },
    init: function (editor) {
        var pluginName = 'videoplayer';
        lang = editor.lang.videoplayer;
        editor.addCommand(pluginName, new CKEDITOR.dialogCommand(pluginName));
        editor.ui.addButton && editor.ui.addButton('VideoPlayer', {
            label: lang.toolbar,
            command: pluginName,
            toolbar: 'insert'
        });

        CKEDITOR.dialog.add(pluginName, this.path + 'dialogs/videoplayer.js');
        
        editor.on('doubleclick', function (evt) {
            var element = evt.data.element;
            if (element.is('img') && element.data('cke-real-element-type') == pluginName)
                evt.data.dialog = pluginName;
        });

        // If the "menu" plugin is loaded, register the menu items.
        if (editor.addMenuItems) {
            editor.addMenuGroup(pluginName);
            editor.addMenuItems({
                videoplayer: {
                    label: lang.properties,
                    command: pluginName,
                    group: pluginName
                }
            });
        }

        // If the "contextmenu" plugin is loaded, register the listeners.
        if (editor.contextMenu) {
            editor.contextMenu.addListener(function (element, selection) {
                if (element && element.is('img') && !element.isReadOnly() && element.data('cke-real-element-type') == pluginName)
                    return { videoplayer: CKEDITOR.TRISTATE_OFF };
            });
        }
    },
    afterInit: function (editor) {
        var dataProcessor = editor.dataProcessor,
            dataFilter = dataProcessor && dataProcessor.dataFilter;

        if (dataFilter) {
            dataFilter.addRules({
                elements: {
                    'cke:object': function (element) {
                        var attributes = element.attributes,
                            classId = attributes.classid && String(attributes.classid).toLowerCase();
                        if (attributes.classid == 'clsid:6bf52a52-394a-11d3-b153-00c04f79faa6') {
                            if (!classId && !isVideoEmbed(element)) {
                                // Look for the inner <embed>
                                for (var i = 0; i < element.children.length; i++) {
                                    if (element.children[i].name == 'cke:embed') {
                                        if (!isVideoEmbed(element.children[i]))
                                            return null;

                                        return createFakeElement(editor, element);
                                    }
                                }
                                return null;
                            }

                            return createFakeElement(editor, element);
                        }
                    },
                    'cke:embed': function (element) {
                        if (!isVideoEmbed(element))
                            return null;

                        return createFakeElement(editor, element);
                    }
                }
            }, 5);
        }
    }
    });
})();
CKEDITOR.tools.extend(CKEDITOR.config, {
    /**
	 * Save as `<embed>` tag only. This tag is unrecommended.
	 *
	 * @cfg {Boolean} [videoEmbedTagOnly=false]
	 * @member CKEDITOR.config
	 */
    videoEmbedTagOnly: false,

    /**
	 * Add `<embed>` tag as alternative: `<object><embed></embed></object>`.
	 *
	 * @cfg {Boolean} [videoAddEmbedTag=false]
	 * @member CKEDITOR.config
	 */
    videoAddEmbedTag: true,

    /**
	 * Use {@link #videoEmbedTagOnly} and {@link #videoAddEmbedTag} values on edit.
	 *
	 * @cfg {Boolean} [videoConvertOnEdit=false]
	 * @member CKEDITOR.config
	 */
    videoConvertOnEdit: false
});
