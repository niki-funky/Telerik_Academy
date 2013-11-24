(function () {

    function imageGalleryRepository() {

        this.save = function () {
            if (!Storage.prototype.save) {
                Storage.prototype.save = function (key, obj) {
                    this.setItem(key, JSON.stringify(obj));
                };
            }
        };

        this.load = function () {
            if (!Storage.prototype.load) {
                Storage.prototype.load = function (key) {
                    return JSON.parse(this.getItem(key));
                };
            }
        };
    }

    return {
        imageGalleryRepository: imageGalleryRepository
    };
}());