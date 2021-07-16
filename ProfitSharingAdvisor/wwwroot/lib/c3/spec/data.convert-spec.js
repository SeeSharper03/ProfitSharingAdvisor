import { c3 } from './c3-helper';
var $$ = c3.chart.internal.fn;
$$.d3 = require('d3');
describe('data.convert', function () {
    describe('$$.convertColumnsToData', function () {
        it('converts column data to normalized data', function () {
            var data = $$.convertColumnsToData([
                ['cat1', 'a', 'b', 'c', 'd'],
                ['data1', 30, 200, 100, 400],
                ['cat2', 'b', 'a', 'c', 'd', 'e', 'f'],
                ['data2', 400, 60, 200, 800, 10, 10]
            ]);
            expect(data).toEqual({
                keys: ['cat1', 'data1', 'cat2', 'data2'],
                rows: [
                    {
                        cat1: 'a',
                        data1: 30,
                        cat2: 'b',
                        data2: 400
                    },
                    {
                        cat1: 'b',
                        data1: 200,
                        cat2: 'a',
                        data2: 60
                    },
                    {
                        cat1: 'c',
                        data1: 100,
                        cat2: 'c',
                        data2: 200
                    },
                    {
                        cat1: 'd',
                        data1: 400,
                        cat2: 'd',
                        data2: 800
                    },
                    {
                        cat2: 'e',
                        data2: 10
                    },
                    {
                        cat2: 'f',
                        data2: 10
                    }
                ]
            });
        });
        it('throws when the column data contains undefined', function () {
            expect(function () {
                return $$.convertColumnsToData([
                    ['cat1', 'a', 'b', 'c', 'd'],
                    ['data1', undefined]
                ]);
            }).toThrowError(Error, /Source data is missing a component/);
        });
    });
    describe('$$.convertRowsToData', function () {
        it('converts the row data to normalized data', function () {
            var data = $$.convertRowsToData([
                ['data1', 'data2', 'data3'],
                [90, 120, 300],
                [40, 160, 240],
                [50, 200, 290],
                [120, 160, 230],
                [80, 130, 300],
                [90, 220, 320]
            ]);
            expect(data).toEqual({
                keys: ['data1', 'data2', 'data3'],
                rows: [
                    {
                        data1: 90,
                        data2: 120,
                        data3: 300
                    },
                    {
                        data1: 40,
                        data2: 160,
                        data3: 240
                    },
                    {
                        data1: 50,
                        data2: 200,
                        data3: 290
                    },
                    {
                        data1: 120,
                        data2: 160,
                        data3: 230
                    },
                    {
                        data1: 80,
                        data2: 130,
                        data3: 300
                    },
                    {
                        data1: 90,
                        data2: 220,
                        data3: 320
                    }
                ]
            });
        });
        it('throws when the row data contains undefined', function () {
            expect(function () {
                return $$.convertRowsToData([
                    ['data1', 'data2', 'data3'],
                    [40, 160, 240],
                    [90, 120, undefined]
                ]);
            }).toThrowError(Error, /Source data is missing a component/);
        });
    });
    describe('$$.convertXsvToData', function () {
        it('converts the csv data to normalized data', function () {
            var data = [
                {
                    data1: '90',
                    data2: '120',
                    data3: '300'
                },
                {
                    data1: '40',
                    data2: '160',
                    data3: '240'
                },
                {
                    data1: '50',
                    data2: '200',
                    data3: '290'
                },
                {
                    data1: '120',
                    data2: '160',
                    data3: '230'
                },
                {
                    data1: '80',
                    data2: '130',
                    data3: '300'
                },
                {
                    data1: '90',
                    data2: '220',
                    data3: '320'
                }
            ];
            data.columns = ['data1', 'data2', 'data3'];
            expect($$.convertXsvToData(data)).toEqual({
                keys: ['data1', 'data2', 'data3'],
                rows: [
                    {
                        data1: '90',
                        data2: '120',
                        data3: '300'
                    },
                    {
                        data1: '40',
                        data2: '160',
                        data3: '240'
                    },
                    {
                        data1: '50',
                        data2: '200',
                        data3: '290'
                    },
                    {
                        data1: '120',
                        data2: '160',
                        data3: '230'
                    },
                    {
                        data1: '80',
                        data2: '130',
                        data3: '300'
                    },
                    {
                        data1: '90',
                        data2: '220',
                        data3: '320'
                    }
                ]
            });
        });
        it('converts one lined CSV data', function () {
            var data = [];
            data.columns = ['data1', 'data2', 'data3'];
            expect($$.convertXsvToData(data)).toEqual({
                keys: ['data1', 'data2', 'data3'],
                rows: [
                    {
                        data1: null,
                        data2: null,
                        data3: null
                    }
                ]
            });
        });
    });
    describe('$$.convertDataToTargets', function () {
        beforeEach(function () {
            $$.cache = {};
            $$.data = {
                xs: []
            };
            $$.config = {
                data_idConverter: function (v) { return v; }
            };
        });
        it('converts the legacy data format into targets', function () {
            var targets = $$.convertDataToTargets([
                {
                    data1: 90,
                    data2: 120,
                    data3: 300
                },
                {
                    data1: 40,
                    data2: 160,
                    data3: 240
                }
            ]);
            expect(targets).toEqual([
                {
                    id: 'data1',
                    id_org: 'data1',
                    values: [
                        { x: 0, value: 90, id: 'data1', index: 0 },
                        { x: 1, value: 40, id: 'data1', index: 1 }
                    ]
                },
                {
                    id: 'data2',
                    id_org: 'data2',
                    values: [
                        { x: 0, value: 120, id: 'data2', index: 0 },
                        { x: 1, value: 160, id: 'data2', index: 1 }
                    ]
                },
                {
                    id: 'data3',
                    id_org: 'data3',
                    values: [
                        { x: 0, value: 300, id: 'data3', index: 0 },
                        { x: 1, value: 240, id: 'data3', index: 1 }
                    ]
                }
            ]);
        });
        it('converts the data into targets', function () {
            var targets = $$.convertDataToTargets({
                keys: ['data1', 'data2', 'data3'],
                rows: [
                    {
                        data1: 90,
                        data2: 120,
                        data3: 300
                    },
                    {
                        data1: 40,
                        data2: 160,
                        data3: 240
                    }
                ]
            });
            expect(targets).toEqual([
                {
                    id: 'data1',
                    id_org: 'data1',
                    values: [
                        { x: 0, value: 90, id: 'data1', index: 0 },
                        { x: 1, value: 40, id: 'data1', index: 1 }
                    ]
                },
                {
                    id: 'data2',
                    id_org: 'data2',
                    values: [
                        { x: 0, value: 120, id: 'data2', index: 0 },
                        { x: 1, value: 160, id: 'data2', index: 1 }
                    ]
                },
                {
                    id: 'data3',
                    id_org: 'data3',
                    values: [
                        { x: 0, value: 300, id: 'data3', index: 0 },
                        { x: 1, value: 240, id: 'data3', index: 1 }
                    ]
                }
            ]);
        });
    });
    describe('$$.convertJsonToData', function () {
        it('converts JSON as object (no keys provided)', function () {
            var data = $$.convertJsonToData({
                data1: [90, 40, 50, 120, 80, 90],
                data2: [120, 160, 200, 160, 130, 220],
                data3: [300, 240, 290, 230, 300, 320]
            });
            expect(data).toEqual({
                keys: ['data1', 'data2', 'data3'],
                rows: [
                    {
                        data1: 90,
                        data2: 120,
                        data3: 300
                    },
                    {
                        data1: 40,
                        data2: 160,
                        data3: 240
                    },
                    {
                        data1: 50,
                        data2: 200,
                        data3: 290
                    },
                    {
                        data1: 120,
                        data2: 160,
                        data3: 230
                    },
                    {
                        data1: 80,
                        data2: 130,
                        data3: 300
                    },
                    {
                        data1: 90,
                        data2: 220,
                        data3: 320
                    }
                ]
            });
        });
        it('converts JSON as rows (keys provided)', function () {
            var data = $$.convertJsonToData([
                {
                    data1: 90,
                    data2: 120,
                    data3: 300,
                    unused: 42
                },
                {
                    data1: 40,
                    data2: 160,
                    data3: 240,
                    unused: 42
                },
                {
                    data1: 50,
                    data2: 200,
                    data3: 290,
                    unused: 42
                },
                {
                    data1: 120,
                    data2: 160,
                    data3: 230,
                    unused: 42
                },
                {
                    data1: 80,
                    data2: 130,
                    data3: 300,
                    unused: 42
                },
                {
                    data1: 90,
                    data2: 220,
                    data3: 320,
                    unused: 42
                }
            ], {
                value: ['data1', 'data2', 'data3']
            });
            expect(data).toEqual({
                keys: ['data1', 'data2', 'data3'],
                rows: [
                    {
                        data1: 90,
                        data2: 120,
                        data3: 300
                    },
                    {
                        data1: 40,
                        data2: 160,
                        data3: 240
                    },
                    {
                        data1: 50,
                        data2: 200,
                        data3: 290
                    },
                    {
                        data1: 120,
                        data2: 160,
                        data3: 230
                    },
                    {
                        data1: 80,
                        data2: 130,
                        data3: 300
                    },
                    {
                        data1: 90,
                        data2: 220,
                        data3: 320
                    }
                ]
            });
        });
    });
});
