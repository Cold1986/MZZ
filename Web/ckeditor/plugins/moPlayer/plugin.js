CKEDITOR.plugins.add('moPlayer',
{
    init: function(editor)    
    {        
        //plugin code goes here
        var pluginName = 'moPlayer';        
        CKEDITOR.dialog.add(pluginName, this.path + 'dialogs/moPlayer.js');        
        editor.addCommand(pluginName, new CKEDITOR.dialogCommand(pluginName));        
       
        editor.ui.addButton('moPlayer',
        {               
            label: '插入魔派视频',
            command: pluginName,
            icon: this.path + 'insertflv.gif'
        });
    }
});
